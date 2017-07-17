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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;

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
        ///     The prevent close.
        /// </summary>
        private bool preventClose = false;

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

            if (!(Settings.Default.MainFormSize.Width == 0 || Settings.Default.MainFormSize.Height == 0))
            {
                this.WindowState = Settings.Default.MainFormWindowState;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.Location = Settings.Default.MainFormLocation;
                this.Size = Settings.Default.MainFormSize;
            }

            this.txtImageDirectory.Text = Settings.Default.ImageDirectory;
            this.chkDeleteFilesWithSameName.Checked = Settings.Default.OptFilesWithSameName;
            this.txtExtension.Text = Settings.Default.OptExtensionToKeep;
            this.radMove.Checked = Settings.Default.OptMoveDuplicates;
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

            this.btnDirectorySelector.Enabled = true;

            this.txtExtension.Enabled = this.chkDeleteFilesWithSameName.Checked;
            this.lblExtension.Enabled = this.chkDeleteFilesWithSameName.Checked;
            this.chkPreferHigherResolution.Enabled = this.chkDeleteFilesWithSameName.Checked;

            if (!this.txtExtension.Enabled)
            {
                this.txtExtension.Text = null;
            }

            if (!this.chkPreferHigherResolution.Enabled)
            {
                this.chkPreferHigherResolution.Checked = false;
            }

            this.txtMoveDirectory.Enabled = this.radMove.Checked;
            this.btnMoveDirectory.Enabled = this.radMove.Checked;

            if (!this.txtMoveDirectory.Enabled)
            {
                this.txtMoveDirectory.Text = null;
            }

            this.chkRequireLikeFileNames.Enabled = this.chkHashCheck.Checked;

            this.btnGo.Enabled = !string.IsNullOrWhiteSpace(this.txtImageDirectory.Text)
                                 && (!this.radMove.Checked
                                     || !string.IsNullOrWhiteSpace(this.txtMoveDirectory.Text))
                                 && (!this.chkDeleteFilesWithSameName.Checked
                                     || (!string.IsNullOrWhiteSpace(this.txtExtension.Text) || this.chkPreferHigherResolution.Checked));
        }

        /// <summary>
        /// The get like file name.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetLikeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return fileName;
            }

            // launchbox uses -01, -02 convention
            int index = fileName.LastIndexOf('-');

            if (index >= 0)
            {
                return fileName.Substring(0, index).Trim();
            }

            return fileName.Trim();
        }

        private void WalkDirectoryTree(
            DirectoryInfo root,
            IProgress<string> outputProgress,
            IProgress<GridOutputRow> gridProgress)
        {
            string extension = this.txtExtension.Text;
            bool testMode = this.radPreview.Checked;
            bool move = this.radMove.Checked;
            bool hash = this.chkHashCheck.Checked;

            outputProgress.Report($"Scanning Directory: {root.Name}");

            FileInfo[] files = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (Exception e)
            {
                outputProgress.Report(e.Message);
            }

            if (files == null)
            {
                return;
            }

            List<string> extensions = new List<string>
                                          {
                                              ".png",
                                              ".jpg",
                                              ".jpeg",
                                              ".bmp",
                                              ".tif",
                                              ".tiff",
                                              ".gif"
                                          };

            List<FileAttribute> fileAttributes = (from f in files
                                                  let fileNameWithoutExtension =
                                                      Path.GetFileNameWithoutExtension(f.Name)
                                                  where extensions.Contains(f.Extension)
                                                  select
                                                      new FileAttribute
                                                          {
                                                              FileInfo = f,
                                                              LikeFileName = this.GetLikeFileName(fileNameWithoutExtension),
                                                              FileNameWithoutExtension = fileNameWithoutExtension,
                                                              FileHash = hash ? GetHashFromFile(f.FullName) : string.Empty,
                                                              Resolution = this.GetResolution(f.FullName)
                                                      }).ToList();

            List<FileAttributeOutput> filesToDelete = new List<FileAttributeOutput>();

            if (this.chkDeleteFilesWithSameName.Checked)
            {
                if (this.chkPreferHigherResolution.Checked)
                {
                    this.DeleteFilesWithSameNameAndLowerResolutions(fileAttributes, filesToDelete);
                }
                else
                {
                    this.DeleteFilesWithSameName(extension, fileAttributes, filesToDelete);
                }
            }

            if (hash)
            {
                this.DeleteFilesWithHashCheck(fileAttributes, filesToDelete);
            }

            foreach (FileAttributeOutput fileToDelete in filesToDelete)
            {
                FileInfo file = fileToDelete?.FileToDelete.FileInfo;

                if (file == null)
                {
                    continue;
                }

                string desc = (move ? "Move" : "Delete") + (testMode ? " (Preview)" : string.Empty);

                outputProgress.Report($"{desc}: {file.FullName}");
                gridProgress.Report(
                    new GridOutputRow
                        {
                            Action = desc,
                            Folder = fileToDelete.FileToDelete.FileInfo.DirectoryName,
                            OriginalFile = fileToDelete.OriginalFile.FileInfo.Name,
                            DuplicateFile = fileToDelete.FileToDelete.FileInfo.Name
                        });

                if (testMode)
                {
                    continue;
                }

                try
                {
                    if (move)
                    {
                        if (file.DirectoryName != null)
                        {
                            string newDirectory = file.DirectoryName.Replace(
                                this.txtImageDirectory.Text,
                                this.txtMoveDirectory.Text);

                            if (!Directory.Exists(newDirectory))
                            {
                                Directory.CreateDirectory(newDirectory);
                            }

                            file.MoveTo(newDirectory + @"\" + file.Name);
                        }
                    }
                    else
                    {
                        file.Delete();
                    }
                }
                catch (Exception e)
                {
                    outputProgress.Report(e.Message);
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
                fileAttributes.GroupBy(
                    f => new { f.FileHash, LikeFileName = requireLikeFileNames ? f.LikeFileName : string.Empty })
                    .Where(group => group.Count() > 1)
                    .Select(
                        group =>
                        fileAttributes.Where(x => this.CompareString(x.FileHash, group.Key.FileHash))
                            .OrderBy(x => x.FileInfo.CreationTimeUtc)
                            .ThenBy(x => x.FileInfo.Name)
                            .Take(1)
                            .SingleOrDefault())
                    .SelectMany(
                        original =>
                        fileAttributes.Where(
                            x =>
                            this.CompareString(x.FileHash, original.FileHash)
                            && !this.CompareString(x.FileInfo.Name, original.FileInfo.Name))
                            .Select(y => new FileAttributeOutput { OriginalFile = original, FileToDelete = y }))
                    .Where(x => x.OriginalFile != null && x.FileToDelete != null)
                    .ToList());

            fileAttributes.RemoveAll(x => filesToDelete.Select(y => y.FileToDelete).ToList().Contains(x));
        }

        /// <summary>
        /// The delete files with same name and lower resolutions.
        /// </summary>
        /// <param name="fileAttributes">
        /// The file attributes.
        /// </param>
        /// <param name="filesToDelete">
        /// The files to delete.
        /// </param>
        private void DeleteFilesWithSameNameAndLowerResolutions(List<FileAttribute> fileAttributes, List<FileAttributeOutput> filesToDelete)
        {
            IEnumerable<IGrouping<string, FileAttribute>> fileGroup = fileAttributes.GroupBy(f => f.FileNameWithoutExtension).Where(group => group.Count() > 1);

            var filesToKeep = fileGroup
                .SelectMany(group => 
                    fileAttributes
                        .Where(x => this.CompareString(x.FileNameWithoutExtension, group.Key))
                        .OrderByDescending(x => x.Resolution)
                        .Take(1)
                        .Select(x => x))
                        .ToDictionary(x => x.FileNameWithoutExtension);

            filesToDelete.AddRange(
                fileAttributes.Select(x => new FileAttributeOutput { OriginalFile = filesToKeep[x.FileNameWithoutExtension], FileToDelete = x })
                    .Where(x => x.OriginalFile != null && x.FileToDelete != null && x.OriginalFile != x.FileToDelete).ToList());

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
                            && !this.CompareString(x.FileInfo.Extension, $".{extension}")))
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
                                        && this.CompareString(y.FileInfo.Extension, $".{extension}")),
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
        /// The btn go_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private async void BtnGoClick(object sender, EventArgs e)
        {
            this.preventClose = true;

            this.progressBar.Text = string.Empty;
            this.progressBar.Value = 0;
            this.grdOutput.Rows.Clear();
            this.grdOutput.Refresh();

            this.txtOutput.Text = string.Empty;

            DirectoryInfo root = new DirectoryInfo(this.txtImageDirectory.Text);

            Progress<string> outputProgressHandler =
                new Progress<string>(
                    value =>
                        {
                            this.txtOutput.AppendText(value + Environment.NewLine);
                        });

            Progress<GridOutputRow> gridProgressHandler = new Progress<GridOutputRow>(
                value =>
                    {
                        this.grdOutput.Rows.Add(value.Action, value.Folder, value.OriginalFile, value.DuplicateFile);
                        this.grdOutput.Refresh();
                    });

            Progress<string> progressBarProgressHandler = new Progress<string>(
                value =>
                    {
                        this.progressBar.Text = value;
                        this.progressBar.PerformStep();
                        this.progressBar.Refresh();

                        if(this.progressBar.Value == this.progressBar.Maximum)
                        {
                            this.progressBar.Text = "Finished!";
                        }
                    });

            IProgress<string> outputProgress = outputProgressHandler;
            IProgress<GridOutputRow> gridProgress = gridProgressHandler;
            IProgress<string> progressBarProgress = progressBarProgressHandler;

            this.btnGo.Enabled = false;
            this.btnDirectorySelector.Enabled = false;

            List<DirectoryInfo> allDirectoryInfos = root.GetDirectories("*", SearchOption.AllDirectories).Where(x => !this.CompareString(x.Name, "Cache")).ToList();
            allDirectoryInfos.Insert(0, root);

            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = allDirectoryInfos.Count;
            this.progressBar.Step = 1;

            await Task.Run(
                () =>
                    {
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            foreach (DirectoryInfo directoryInfo in allDirectoryInfos)
                            {
                                progressBarProgress.Report(directoryInfo.FullName);

                                this.WalkDirectoryTree(
                                    directoryInfo,
                                    outputProgress,
                                    gridProgress);
                            }
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    });

            outputProgress.Report("Finished!");
            this.InitControls();

            this.preventClose = false;
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
            string originalImage = senderGrid.Rows[e.RowIndex].Cells["OriginalImage"].Value?.ToString();
            string dupImage = senderGrid.Rows[e.RowIndex].Cells["DuplicateImage"].Value?.ToString();

            if (senderGrid.Columns[e.ColumnIndex].Name == "OpenFolder")
            {
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name == "ViewImages")
            {
                ImageViewerForm viewer = new ImageViewerForm();
                viewer.OriginalImagePath = folder + @"\" + originalImage;
                viewer.DupImagePath = folder + @"\" + dupImage;
                viewer.Owner = this;
                viewer.Show();
            }
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
            if(e.CloseReason == CloseReason.UserClosing && this.preventClose)
            {
                e.Cancel = true;
                MessageBox.Show("Please wait until the operation completes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Settings.Default.ImageDirectory = this.txtImageDirectory.Text;
                Settings.Default.OptFilesWithSameName = this.chkDeleteFilesWithSameName.Checked;
                Settings.Default.OptExtensionToKeep = this.txtExtension.Text;
                Settings.Default.OptMoveDuplicates = this.radMove.Checked;
                Settings.Default.MoveDirectory = this.txtMoveDirectory.Text;
                Settings.Default.OptHashCheck = this.chkHashCheck.Checked;
                Settings.Default.OptRequireLikeFileNames = this.chkRequireLikeFileNames.Checked;

                Settings.Default.MainFormWindowState = this.WindowState;

                if (this.WindowState == FormWindowState.Normal)
                {
                    // save location and size if the state is normal
                    Settings.Default.MainFormLocation = this.Location;
                    Settings.Default.MainFormSize = this.Size;
                }
                else
                {
                    // save the RestoreBounds if the form is minimized or maximized!
                    Settings.Default.MainFormLocation = this.RestoreBounds.Location;
                    Settings.Default.MainFormSize = this.RestoreBounds.Size;
                }

                Settings.Default.Save();
            }
        }

        /// <summary>
        /// The chk prefer higher resolution checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ChkPreferHigherResolutionCheckedChanged(object sender, EventArgs e)
        {
               this.InitControls();
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

            this.chkRequireLikeFileNames.Checked = this.chkHashCheck.Checked;
        }

        /// <summary>
        /// The pnl options resize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PnlOptionsResize(object sender, EventArgs e)
        {
            this.grpOptions.Width = (int)(this.pnlOptions.Width * .55m);
            this.grpOptions.Height = this.pnlOptions.Height;
            this.grpOptions.Top = 0;
            this.grpOptions.Left = 0;

            this.grpCleanupOptions.Width = (int)(this.pnlOptions.Width * .45m);
            this.grpCleanupOptions.Height = this.pnlOptions.Height;
            this.grpCleanupOptions.Top = 0;
            this.grpCleanupOptions.Left = this.grpOptions.Right + 6;
        }

        /// <summary>
        /// The rad move checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RadMoveCheckedChanged(object sender, EventArgs e)
        {
            this.InitControls();
        }

        /// <summary>
        /// The get resolution.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetResolution(string fileName)
        {
            int resolution;

            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (Image img = Image.FromStream(file, false, false))
                {
                    float width = img.PhysicalDimension.Width;
                    float height = img.PhysicalDimension.Height;

                    resolution = (int)(width * height);
                }
            }

            return resolution;
        }

        /// <summary>
        /// The grid output row.
        /// </summary>
        private sealed class GridOutputRow
        {
            /// <summary>
            /// Gets or sets the action.
            /// </summary>
            public string Action { get; set; }

            /// <summary>
            /// Gets or sets the folder.
            /// </summary>
            public string Folder { get; set; }

            /// <summary>
            /// Gets or sets the original file.
            /// </summary>
            public string OriginalFile { get; set; }

            /// <summary>
            /// Gets or sets the duplicate file.
            /// </summary>
            public string DuplicateFile { get; set; }
        }
    }
}