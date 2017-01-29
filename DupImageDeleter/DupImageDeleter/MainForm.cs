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
using System.Security.Cryptography;
using System.Diagnostics;

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

            this.txtMoveDirectory.Enabled = chkMoveInsteadOfDelete.Checked;
            this.btnMoveDirectory.Enabled = chkMoveInsteadOfDelete.Checked;

            if (!this.txtMoveDirectory.Enabled)
            {
                this.txtMoveDirectory.Text = null;
            }

            this.btnGo.Enabled = 
                !string.IsNullOrWhiteSpace(this.txtImageDirectory.Text) 
                && (!this.chkMoveInsteadOfDelete.Checked || !string.IsNullOrWhiteSpace(this.txtMoveDirectory.Text))
                && 
                (
                    (this.chkDeleteFilesWithSameName.Checked && !string.IsNullOrWhiteSpace(this.txtExtension.Text))
                    || 
                    (1 == 0) // add more options here
                );
        }

        private void WalkDirectoryTree(DirectoryInfo root)
        {
            string extension = this.txtExtension.Text;
            bool testMode = chkTestMode.Checked;
            bool move = chkMoveInsteadOfDelete.Checked;

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
                                          FileFolder = f.DirectoryName,
                                          FileName = f.Name,
                                          FileNameWithoutExtension = Path.GetFileNameWithoutExtension(f.Name),
                                          FileExtension = f.Extension,
                                          FileHash = GetMD5HashFromFile(f.FullName),
                                          FileCreationTime = f.CreationTimeUtc
                                      }).ToList();

                // delete files where the file name matches but the extension doesnt
                //******************************************************************
                var filesToDelete =
                    fileAttributes
                        .GroupBy(f => f.FileNameWithoutExtension)
                        .Where(group => group.Count() > 1)
                        .SelectMany(group => fileAttributes.Where(x => this.CompareString(x.FileNameWithoutExtension, group.Key) && !this.CompareString(x.FileExtension, $".{extension}")))
                        .Select(x => new
                        {
                            OriginalFile = fileAttributes.SingleOrDefault(y => this.CompareString(y.FileNameWithoutExtension, x.FileNameWithoutExtension) && this.CompareString(y.FileExtension, $".{extension}")),
                            FileToDelete = x
                        })
                        .ToList();

                fileAttributes.RemoveAll(x => filesToDelete.Select(y => y.FileToDelete).ToList().Contains(x));
                //******************************************************************

                ////******************************************************************
                //filesToDelete.AddRange(
                //    fileAttributes
                //        .GroupBy(f => f.FileHash)
                //        .Where(group => group.Count() > 1)
                //        .Select(group =>
                //            fileAttributes
                //                .Where(x => string.Equals(x.FileHash, group.Key, StringComparison.OrdinalIgnoreCase))
                //                .OrderByDescending(x => x.FileCreationTime)
                //                .ThenByDescending(x => x.FileName).Take(1).SingleOrDefault()).ToList());

                //fileAttributes.RemoveAll(x => filesToDelete.Contains(x));
                ////******************************************************************

                foreach (var fileToDelete in filesToDelete)
                {
                    if (fileToDelete != null)
                    {
                        var file = root.GetFiles(fileToDelete.FileToDelete.FileName).SingleOrDefault();

                        if (file != null)
                        {
                            string desc = (move ? "Move" : "Delete") + (testMode ? " (Test Mode)" : string.Empty);

                            this.AddToOutput($"{desc}: {file.FullName}");
                            this.AddToGrid(desc, fileToDelete.FileToDelete.FileFolder, fileToDelete.OriginalFile?.FileName, fileToDelete.FileToDelete.FileName);

                            if (!testMode)
                            {
                                try
                                {
                                    if(move)
                                    {
                                        file.MoveTo(this.txtMoveDirectory.Text + @"\" + file.Name);
                                    }
                                    else
                                    {
                                        file.Delete();
                                    }
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
                    if(!this.CompareString(dirInfo.Name, "Cache"))
                    {
                        this.WalkDirectoryTree(dirInfo);
                    }
                }
            }
        }

        private bool CompareString(string string1, string string2)
        {
            return string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase);
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        private void AddToOutput(string output)
        {
            this.txtOutput.AppendText(output + Environment.NewLine);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.grdOutput.Rows.Clear();
            this.grdOutput.Refresh();

            this.txtOutput.Text = string.Empty;

            DirectoryInfo root = new DirectoryInfo(this.txtImageDirectory.Text);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.WalkDirectoryTree(root);

                this.AddToOutput("Finished!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void chkMoveInsteadOfDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void btnMoveDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = moveDirectoryBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtMoveDirectory.Text = moveDirectoryBrowser.SelectedPath;
            }
        }

        private void txtImageDirectory_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void txtExtension_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void txtMoveDirectory_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        private void grdOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string folder = senderGrid.Rows[e.RowIndex].Cells["Folder"].Value?.ToString();

                if(!string.IsNullOrWhiteSpace(folder))
                {
                    try
                    {
                        Process.Start(folder);
                    }
                    catch (Exception ex)
                    {
                        this.AddToOutput(ex.Message);
                    }
                }
            }
        }

        private void AddToGrid(string action, string folder, string originalFile, string duplicateFile)
        {
            this.grdOutput.Rows.Add(action, folder, originalFile, duplicateFile);
            this.grdOutput.Refresh();
        }
    }
}
