﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    using DupImageDeleter.Properties;

    /// <summary>
    ///     The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     The fire init controls.
        /// </summary>
        private bool fireInitControls = true;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainForm" /> class.
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
        private void BtnDirectorySelectorClick(object sender, EventArgs e)
        {
            string selectedPath = this.txtImageDirectory.Text;

            if (!string.IsNullOrWhiteSpace(selectedPath))
            {
                this.folderBrowser.SelectedPath = selectedPath;
            }

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
        private void ChkDeleteFilesWithSameNameCheckedChanged(object sender, EventArgs e)
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
        private void MainFormLoad(object sender, EventArgs e)
        {
            this.fireInitControls = false;

            this.txtImageDirectory.Text = Settings.Default.ImageDirectory;
            this.chkDeleteFilesWithSameName.Checked = Settings.Default.OptFilesWithSameName;
            this.txtExtension.Text = Settings.Default.OptExtensionToKeep;
            this.chkMoveInsteadOfDelete.Checked = Settings.Default.OptMoveDuplicates;
            this.txtMoveDirectory.Text = Settings.Default.MoveDirectory;
            this.chkHashCheck.Checked = Settings.Default.OptHashCheck;
            this.chkRequireLikeFileNames.Checked = Settings.Default.OptRequireLikeFileNames;

            this.fireInitControls = true;

            this.InitControls();
        }

        /// <summary>
        ///     The init controls.
        /// </summary>
        private void InitControls()
        {
            if (!this.fireInitControls)
            {
                return;
            }

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

            this.chkRequireLikeFileNames.Enabled = this.chkHashCheck.Checked;

            if (!this.chkRequireLikeFileNames.Enabled)
            {
                this.chkRequireLikeFileNames.Checked = false;
            }

            this.btnGo.Enabled = !string.IsNullOrWhiteSpace(this.txtImageDirectory.Text)
                                 && (!this.chkMoveInsteadOfDelete.Checked
                                     || !string.IsNullOrWhiteSpace(this.txtMoveDirectory.Text))
                                 && (!this.chkDeleteFilesWithSameName.Checked
                                     || !string.IsNullOrWhiteSpace(this.txtExtension.Text));
        }

        private string GetLikeFileName(string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName))
            {
                return fileName;
            }

            // launchbox uses -01, -02 convention
            int index = fileName.LastIndexOf('-');

            if(index >= 0)
            {
                return fileName.Substring(0, index);
            }

            return fileName;
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

            List<FileAttribute> fileAttributes = (from f in files
                                                  let fileNameWithoutExtension = Path.GetFileNameWithoutExtension(f.Name)
                                                  select
                                                      new FileAttribute
                                                      {
                                                          FileFolder = f.DirectoryName,
                                                          FileName = f.Name,
                                                          LikeFileName = this.GetLikeFileName(fileNameWithoutExtension),
                                                          FileNameWithoutExtension = fileNameWithoutExtension,
                                                          FileExtension = f.Extension,
                                                          FileHash = GetHashFromFile(f.FullName),
                                                          FileCreationTime = f.CreationTimeUtc
                                                      }).ToList();

            List<FileAttributeOutput> filesToDelete = new List<FileAttributeOutput>();

            if (this.chkDeleteFilesWithSameName.Checked)
            {
                this.DeleteFilesWithSameName(extension, fileAttributes, filesToDelete);
            }

            if (this.chkHashCheck.Checked)
            {
                this.DeleteFilesWithHashCheck(fileAttributes, filesToDelete);
            }

            foreach (FileAttributeOutput fileToDelete in filesToDelete)
            {
                if (fileToDelete == null)
                {
                    continue;
                }

                FileInfo file = root.GetFiles(fileToDelete.FileToDelete.FileName).SingleOrDefault();

                if (file == null)
                {
                    continue;
                }

                string desc = (move ? "Move" : "Delete") + (testMode ? " (Test Mode)" : string.Empty);

                this.AddToOutput($"{desc}: {file.FullName}");
                this.AddToGrid(
                    desc,
                    fileToDelete.FileToDelete.FileFolder,
                    fileToDelete.OriginalFile?.FileName,
                    fileToDelete.FileToDelete.FileName);

                if (testMode)
                {
                    continue;
                }

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
        /// The delete files with hash check.
        /// </summary>
        /// <param name="fileAttributes">
        /// The file attributes.
        /// </param>
        /// <param name="filesToDelete">
        /// The files to delete.
        /// </param>
        private void DeleteFilesWithHashCheck(
            List<FileAttribute> fileAttributes,
            List<FileAttributeOutput> filesToDelete)
        {
            bool requireLikeFileNames = this.chkRequireLikeFileNames.Checked;

            filesToDelete.AddRange(
                fileAttributes
                    .GroupBy(f => new { f.FileHash, LikeFileName = requireLikeFileNames ? f.LikeFileName : string.Empty })
                    .Where(group => group.Count() > 1)
                    .Select(
                        group =>
                        fileAttributes.Where(x => this.CompareString(x.FileHash, group.Key.FileHash))
                            .OrderBy(x => x.FileCreationTime)
                            .ThenBy(x => x.FileName)
                            .Take(1)
                            .SingleOrDefault())
                    .SelectMany(
                        original =>
                        fileAttributes.Where(
                            x =>
                            this.CompareString(x.FileHash, original.FileHash) && !this.CompareString(x.FileName, original.FileName))
                            .Select(y => new FileAttributeOutput { OriginalFile = original, FileToDelete = y }))
                    .Where(x => x.OriginalFile != null && x.FileToDelete != null)
                    .ToList());

            fileAttributes.RemoveAll(x => filesToDelete.Select(y => y.FileToDelete).ToList().Contains(x));
        }

        /// <summary>
        /// The delete files with same name.
        /// </summary>
        /// <param name="extension">
        /// The extension.
        /// </param>
        /// <param name="fileAttributes">
        /// The file attributes.
        /// </param>
        /// <param name="filesToDelete">
        /// The files to delete.
        /// </param>
        private void DeleteFilesWithSameName(
            string extension,
            List<FileAttribute> fileAttributes,
            List<FileAttributeOutput> filesToDelete)
        {
            filesToDelete.AddRange(
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
                        new FileAttributeOutput
                            {
                                OriginalFile =
                                    fileAttributes.SingleOrDefault(
                                        y =>
                                        this.CompareString(
                                            y.FileNameWithoutExtension,
                                            x.FileNameWithoutExtension)
                                        && this.CompareString(y.FileExtension, $".{extension}")),
                                FileToDelete = x
                            })
                    .Where(x => x.OriginalFile != null && x.FileToDelete != null)
                    .ToList());

            fileAttributes.RemoveAll(x => filesToDelete.Select(y => y.FileToDelete).ToList().Contains(x));
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
        /// The get hash from file.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetHashFromFile(string fileName)
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
        private void BtnGoClick(object sender, EventArgs e)
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
        private void ChkMoveInsteadOfDeleteCheckedChanged(object sender, EventArgs e)
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
        private void BtnMoveDirectoryClick(object sender, EventArgs e)
        {
            string selectedPath = this.txtMoveDirectory.Text;

            if (!string.IsNullOrWhiteSpace(selectedPath))
            {
                this.moveDirectoryBrowser.SelectedPath = selectedPath;
            }

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
        private void TxtImageDirectoryTextChanged(object sender, EventArgs e)
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
        private void TxtExtensionTextChanged(object sender, EventArgs e)
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
        private void TxtMoveDirectoryTextChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The Grd output_ cell content click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GrdOutputCellContentClick(object sender, DataGridViewCellEventArgs e)
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

        /// <summary>
        /// The main form form closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ImageDirectory = this.txtImageDirectory.Text;
            Settings.Default.OptFilesWithSameName = this.chkDeleteFilesWithSameName.Checked;
            Settings.Default.OptExtensionToKeep = this.txtExtension.Text;
            Settings.Default.OptMoveDuplicates = this.chkMoveInsteadOfDelete.Checked;
            Settings.Default.MoveDirectory = this.txtMoveDirectory.Text;
            Settings.Default.OptHashCheck = this.chkHashCheck.Checked;
            Settings.Default.OptRequireLikeFileNames = this.chkRequireLikeFileNames.Checked;

            Settings.Default.Save();
        }

        /// <summary>
        /// The chk hash check checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ChkHashCheckCheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        ///     The file attribute.
        /// </summary>
        private sealed class FileAttribute
        {
            /// <summary>
            ///     Gets or sets the file folder.
            /// </summary>
            public string FileFolder { get; set; }

            /// <summary>
            ///     Gets or sets the file name.
            /// </summary>
            public string FileName { get; set; }

            public string LikeFileName { get; set; }

            /// <summary>
            ///     Gets or sets the file name without extension.
            /// </summary>
            public string FileNameWithoutExtension { get; set; }

            /// <summary>
            ///     Gets or sets the file extension.
            /// </summary>
            public string FileExtension { get; set; }

            /// <summary>
            ///     Gets or sets the file hash.
            /// </summary>
            public string FileHash { get; set; }

            /// <summary>
            ///     Gets or sets the file creation time.
            /// </summary>
            public DateTime FileCreationTime { get; set; }
        }

        /// <summary>
        ///     The file attribute output.
        /// </summary>
        private sealed class FileAttributeOutput
        {
            /// <summary>
            ///     Gets or sets the original file.
            /// </summary>
            public FileAttribute OriginalFile { get; set; }

            /// <summary>
            ///     Gets or sets the file to delete.
            /// </summary>
            public FileAttribute FileToDelete { get; set; }
        }
    }
}