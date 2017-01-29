// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="">
//
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DupImageDeleter
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The btn directory selector_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnDirectorySelector_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtImageDirectory.Text = this.folderBrowser.SelectedPath;
            }
        }

        /// <summary>
        /// The chk delete files with same name_ checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void chkDeleteFilesWithSameName_CheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The main form_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The init controls.
        /// </summary>
        private void InitControls()
        {
            this.txtExtension.Enabled = this.chkDeleteFilesWithSameName.Checked;
            this.lblExtension.Enabled = this.chkDeleteFilesWithSameName.Checked;

            if (!this.txtExtension.Enabled)
            {
                this.txtExtension.Text = null;
            }

            this.txtMoveDirectory.Enabled = this.chkMoveInsteadOfDelete.Checked;
            this.btnMoveDirectory.Enabled = this.chkMoveInsteadOfDelete.Checked;

            if (!this.txtMoveDirectory.Enabled)
            {
                this.txtMoveDirectory.Text = null;
            }

            this.btnGo.Enabled = !string.IsNullOrWhiteSpace(this.txtImageDirectory.Text)
                                 && (!this.chkMoveInsteadOfDelete.Checked
                                     || !string.IsNullOrWhiteSpace(this.txtMoveDirectory.Text))
                                 && ((this.chkDeleteFilesWithSameName.Checked
                                      && !string.IsNullOrWhiteSpace(this.txtExtension.Text)) || (1 == 0)

                                    // add more options here
                                    );
        }

        /// <summary>
        /// The walk directory tree.
        /// </summary>
        /// <param name="root">
        /// The root.
        /// </param>
        private void WalkDirectoryTree(DirectoryInfo root)
        {
            string extension = this.txtExtension.Text;
            bool testMode = this.chkTestMode.Checked;
            bool move = this.chkMoveInsteadOfDelete.Checked;

            FileInfo[] files = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (Exception e)
            {
                this.AddToOutput(e.Message);
            }

            if (files == null)
            {
                return;
            }

            var fileAttributes = (from f in files
                                  select
                                      new
                                          {
                                              FileFolder = f.DirectoryName,
                                              FileName = f.Name,
                                              FileNameWithoutExtension = Path.GetFileNameWithoutExtension(f.Name),
                                              FileExtension = f.Extension,
                                              FileHash = GetMD5HashFromFile(f.FullName),
                                              FileCreationTime = f.CreationTimeUtc
                                          }).ToList();

            // delete files where the file name matches but the extension doesnt
            // ******************************************************************
            var filesToDelete =
                fileAttributes.GroupBy(f => f.FileNameWithoutExtension)
                    .Where(group => @group.Count() > 1)
                    .SelectMany(
                        group =>
                        fileAttributes.Where(
                            x =>
                            this.CompareString(x.FileNameWithoutExtension, @group.Key)
                            && !this.CompareString(x.FileExtension, $".{extension}")))
                    .Select(
                        x =>
                        new
                            {
                                OriginalFile =
                            fileAttributes.SingleOrDefault(
                                y =>
                                this.CompareString(y.FileNameWithoutExtension, x.FileNameWithoutExtension)
                                && this.CompareString(y.FileExtension, $".{extension}")),
                                FileToDelete = x
                            })
                    .ToList();

            fileAttributes.RemoveAll(x => filesToDelete.Select(y => y.FileToDelete).ToList().Contains(x));

            // ******************************************************************

            ////******************************************************************
            // filesToDelete.AddRange(
            // fileAttributes
            // .GroupBy(f => f.FileHash)
            // .Where(group => group.Count() > 1)
            // .Select(group =>
            // fileAttributes
            // .Where(x => string.Equals(x.FileHash, group.Key, StringComparison.OrdinalIgnoreCase))
            // .OrderByDescending(x => x.FileCreationTime)
            // .ThenByDescending(x => x.FileName).Take(1).SingleOrDefault()).ToList());

            // fileAttributes.RemoveAll(x => filesToDelete.Contains(x));
            ////******************************************************************
            foreach (var fileToDelete in filesToDelete)
            {
                if (fileToDelete != null)
                {
                    FileInfo file = root.GetFiles(fileToDelete.FileToDelete.FileName).SingleOrDefault();

                    if (file != null)
                    {
                        string desc = (move ? "Move" : "Delete") + (testMode ? " (Test Mode)" : string.Empty);

                        this.AddToOutput($"{desc}: {file.FullName}");
                        this.AddToGrid(
                            desc,
                            fileToDelete.FileToDelete.FileFolder,
                            fileToDelete.OriginalFile?.FileName,
                            fileToDelete.FileToDelete.FileName);

                        if (!testMode)
                        {
                            try
                            {
                                if (move)
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
                if (!this.CompareString(dirInfo.Name, "Cache"))
                {
                    this.WalkDirectoryTree(dirInfo);
                }
            }
        }

        /// <summary>
        /// The compare string.
        /// </summary>
        /// <param name="string1">
        /// The string 1.
        /// </param>
        /// <param name="string2">
        /// The string 2.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CompareString(string string1, string string2)
        {
            return string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// The get m d 5 hash from file.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetMD5HashFromFile(string fileName)
        {
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        /// <summary>
        /// The add to output.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        private void AddToOutput(string output)
        {
            this.txtOutput.AppendText(output + Environment.NewLine);
        }

        /// <summary>
        /// The btn go_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
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

        /// <summary>
        /// The chk move instead of delete_ checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void chkMoveInsteadOfDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The btn move directory_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnMoveDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = this.moveDirectoryBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.txtMoveDirectory.Text = this.moveDirectoryBrowser.SelectedPath;
            }
        }

        /// <summary>
        /// The txt image directory_ text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtImageDirectory_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The txt extension_ text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtExtension_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The txt move directory_ text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void txtMoveDirectory_TextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The grd output_ cell content click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void grdOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
            {
                return;
            }

            string folder = senderGrid.Rows[e.RowIndex].Cells["Folder"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(folder))
            {
                return;
            }

            try
            {
                Process.Start(folder);
            }
            catch (Exception ex)
            {
                this.AddToOutput(ex.Message);
            }
        }

        /// <summary>
        /// The add to grid.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="folder">
        /// The folder.
        /// </param>
        /// <param name="originalFile">
        /// The original file.
        /// </param>
        /// <param name="duplicateFile">
        /// The duplicate file.
        /// </param>
        private void AddToGrid(string action, string folder, string originalFile, string duplicateFile)
        {
            this.grdOutput.Rows.Add(action, folder, originalFile, duplicateFile);
            this.grdOutput.Refresh();
        }
    }
}