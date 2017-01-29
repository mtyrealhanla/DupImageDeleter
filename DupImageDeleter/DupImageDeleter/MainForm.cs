using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupImageDeleter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDirectorySelector_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.txtImageDirectory.Text = folderBrowser.SelectedPath;
            }
        }

        private void chkDeleteFilesWithSameName_CheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void InitControls()
        {
            this.txtExtension.Enabled = chkDeleteFilesWithSameName.Checked;
            this.lblExtension.Enabled = chkDeleteFilesWithSameName.Checked;

            if (!this.txtExtension.Enabled)
            {
                this.txtExtension.Text = null;
            }

            this.btnGo.Enabled = 
                !string.IsNullOrWhiteSpace(this.txtImageDirectory.Text) 
                && 
                (
                    this.chkDeleteFilesWithSameName.Checked && !string.IsNullOrWhiteSpace(this.txtExtension.Text)
                    // add more options here
                );
        }

        private void WalkDirectoryTree(DirectoryInfo root, string extension, bool testMode)
        {
            FileInfo[] files = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (Exception e)
            {
                this.AddToOutput(e.Message);
            }
            
            if (files != null)
            {
                var fileAttributes = (from f in files
                                      select new
                                      {
                                          FileName = f.Name,
                                          FileNameWithoutExtension = Path.GetFileNameWithoutExtension(f.Name),
                                          FileExtension = f.Extension,
                                          FileCreationTime = f.CreationTimeUtc
                                      }).ToList();

                // delete files where the file name matches but the extension doesnt
                //******************************************************************
                var filesToDelete =
                    fileAttributes
                        .GroupBy(f => f.FileNameWithoutExtension)
                        .Where(group => group.Count() > 1)
                        .Select(group => fileAttributes.SingleOrDefault(x =>
                                string.Equals(x.FileNameWithoutExtension, group.Key, StringComparison.OrdinalIgnoreCase)
                                && string.Equals(x.FileExtension, $".{extension}", StringComparison.OrdinalIgnoreCase)))
                        .ToList();

                fileAttributes.RemoveAll(x => filesToDelete.Contains(x));
                //******************************************************************

                foreach (var fileToDelete in filesToDelete)
                {
                    if (fileToDelete != null)
                    {
                        var file = root.GetFiles(fileToDelete.FileName).SingleOrDefault();

                        if (file != null)
                        {
                            if (testMode)
                            {
                                this.AddToOutput($"Would delete: {file.FullName}");
                            }
                            else
                            {
                                this.AddToOutput($"Deleting: {file.FullName}");

                                try
                                {
                                    file.Delete();
                                }
                                catch (Exception e)
                                {
                                    this.AddToOutput(e.Message);
                                }
                            }
                        }
                    }
                }

                DirectoryInfo[] subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    if(!string.Equals(dirInfo.Name, "Cache", StringComparison.OrdinalIgnoreCase))
                    {
                        this.WalkDirectoryTree(dirInfo, extension, testMode);
                    }
                }
            }
        }

        private void AddToOutput(string output)
        {
            this.txtOutput.AppendText(output + Environment.NewLine);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.txtOutput.Text = string.Empty;

            DirectoryInfo root = new DirectoryInfo(this.txtImageDirectory.Text);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WalkDirectoryTree(root, this.txtExtension.Text, chkTestMode.Checked);

                this.AddToOutput("Finished!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void txtImageDirectory_Leave(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void txtExtension_Leave(object sender, EventArgs e)
        {
            this.InitControls();
        }
    }
}
