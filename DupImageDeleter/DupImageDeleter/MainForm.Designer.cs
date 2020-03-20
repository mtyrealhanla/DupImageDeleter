namespace DupImageDeleter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.lblImageDirectory = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDirectorySelector = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkExcludeGameplay = new System.Windows.Forms.CheckBox();
            this.chkLikeFileNames = new System.Windows.Forms.CheckBox();
            this.chkSearchTopDirectoriesOnly = new System.Windows.Forms.CheckBox();
            this.chkPreferHigherResolution = new System.Windows.Forms.CheckBox();
            this.chkRequireLikeFileNames = new System.Windows.Forms.CheckBox();
            this.chkHashCheck = new System.Windows.Forms.CheckBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkDeleteFilesWithSameName = new System.Windows.Forms.CheckBox();
            this.btnMoveDirectory = new System.Windows.Forms.Button();
            this.txtMoveDirectory = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.moveDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grdOutput = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFolder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewImages = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.grpCleanupOptions = new System.Windows.Forms.GroupBox();
            this.radMoveToUS = new System.Windows.Forms.RadioButton();
            this.radMove = new System.Windows.Forms.RadioButton();
            this.radDelete = new System.Windows.Forms.RadioButton();
            this.radPreview = new System.Windows.Forms.RadioButton();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.txtImageDirectory = new System.Windows.Forms.TextBox();
            this.progressBar = new DupImageDeleter.TextProgressBar();
            this.btnViewDiffs = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutput)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGrid.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.grpCleanupOptions.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(857, 633);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGoClick);
            // 
            // lblImageDirectory
            // 
            this.lblImageDirectory.AutoSize = true;
            this.lblImageDirectory.Location = new System.Drawing.Point(12, 9);
            this.lblImageDirectory.Name = "lblImageDirectory";
            this.lblImageDirectory.Size = new System.Drawing.Size(81, 13);
            this.lblImageDirectory.TabIndex = 0;
            this.lblImageDirectory.Text = "Image Directory";
            // 
            // btnDirectorySelector
            // 
            this.btnDirectorySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectorySelector.Location = new System.Drawing.Point(905, 30);
            this.btnDirectorySelector.Name = "btnDirectorySelector";
            this.btnDirectorySelector.Size = new System.Drawing.Size(27, 23);
            this.btnDirectorySelector.TabIndex = 2;
            this.btnDirectorySelector.Text = "...";
            this.btnDirectorySelector.UseVisualStyleBackColor = true;
            this.btnDirectorySelector.Click += new System.EventHandler(this.BtnDirectorySelectorClick);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkExcludeGameplay);
            this.grpOptions.Controls.Add(this.chkLikeFileNames);
            this.grpOptions.Controls.Add(this.chkSearchTopDirectoriesOnly);
            this.grpOptions.Controls.Add(this.chkPreferHigherResolution);
            this.grpOptions.Controls.Add(this.chkRequireLikeFileNames);
            this.grpOptions.Controls.Add(this.chkHashCheck);
            this.grpOptions.Controls.Add(this.lblExtension);
            this.grpOptions.Controls.Add(this.txtExtension);
            this.grpOptions.Controls.Add(this.chkDeleteFilesWithSameName);
            this.grpOptions.Location = new System.Drawing.Point(0, 0);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(581, 184);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Search Options";
            // 
            // chkExcludeGameplay
            // 
            this.chkExcludeGameplay.AutoSize = true;
            this.chkExcludeGameplay.Location = new System.Drawing.Point(6, 158);
            this.chkExcludeGameplay.Name = "chkExcludeGameplay";
            this.chkExcludeGameplay.Size = new System.Drawing.Size(155, 17);
            this.chkExcludeGameplay.TabIndex = 8;
            this.chkExcludeGameplay.Text = "Exclude Gameplay / Fanart";
            this.chkExcludeGameplay.UseVisualStyleBackColor = true;
            // 
            // chkLikeFileNames
            // 
            this.chkLikeFileNames.AutoSize = true;
            this.chkLikeFileNames.Location = new System.Drawing.Point(6, 112);
            this.chkLikeFileNames.Name = "chkLikeFileNames";
            this.chkLikeFileNames.Size = new System.Drawing.Size(203, 17);
            this.chkLikeFileNames.TabIndex = 6;
            this.chkLikeFileNames.Text = "LIke File Names (Game-01, Game-02)";
            this.chkLikeFileNames.UseVisualStyleBackColor = true;
            // 
            // chkSearchTopDirectoriesOnly
            // 
            this.chkSearchTopDirectoriesOnly.AutoSize = true;
            this.chkSearchTopDirectoriesOnly.Location = new System.Drawing.Point(6, 135);
            this.chkSearchTopDirectoriesOnly.Name = "chkSearchTopDirectoriesOnly";
            this.chkSearchTopDirectoriesOnly.Size = new System.Drawing.Size(159, 17);
            this.chkSearchTopDirectoriesOnly.TabIndex = 7;
            this.chkSearchTopDirectoriesOnly.Text = "Search Top Directories Only";
            this.chkSearchTopDirectoriesOnly.UseVisualStyleBackColor = true;
            // 
            // chkPreferHigherResolution
            // 
            this.chkPreferHigherResolution.AutoSize = true;
            this.chkPreferHigherResolution.Location = new System.Drawing.Point(210, 45);
            this.chkPreferHigherResolution.Name = "chkPreferHigherResolution";
            this.chkPreferHigherResolution.Size = new System.Drawing.Size(146, 17);
            this.chkPreferHigherResolution.TabIndex = 3;
            this.chkPreferHigherResolution.Text = "Prefer Highest Resolution";
            this.chkPreferHigherResolution.UseVisualStyleBackColor = true;
            this.chkPreferHigherResolution.CheckedChanged += new System.EventHandler(this.ChkPreferHigherResolutionCheckedChanged);
            // 
            // chkRequireLikeFileNames
            // 
            this.chkRequireLikeFileNames.AutoSize = true;
            this.chkRequireLikeFileNames.Location = new System.Drawing.Point(39, 89);
            this.chkRequireLikeFileNames.Name = "chkRequireLikeFileNames";
            this.chkRequireLikeFileNames.Size = new System.Drawing.Size(259, 17);
            this.chkRequireLikeFileNames.TabIndex = 5;
            this.chkRequireLikeFileNames.Text = "Require Like File Names (i.e. Game-01, Game-02)";
            this.chkRequireLikeFileNames.UseVisualStyleBackColor = true;
            // 
            // chkHashCheck
            // 
            this.chkHashCheck.AutoSize = true;
            this.chkHashCheck.Location = new System.Drawing.Point(6, 66);
            this.chkHashCheck.Name = "chkHashCheck";
            this.chkHashCheck.Size = new System.Drawing.Size(125, 17);
            this.chkHashCheck.TabIndex = 4;
            this.chkHashCheck.Text = "Files with same Hash";
            this.chkHashCheck.UseVisualStyleBackColor = true;
            this.chkHashCheck.CheckedChanged += new System.EventHandler(this.ChkHashCheckCheckedChanged);
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(36, 46);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(93, 13);
            this.lblExtension.TabIndex = 1;
            this.lblExtension.Text = "Extension to Keep";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(135, 43);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(69, 20);
            this.txtExtension.TabIndex = 2;
            this.txtExtension.TextChanged += new System.EventHandler(this.TxtExtensionTextChanged);
            // 
            // chkDeleteFilesWithSameName
            // 
            this.chkDeleteFilesWithSameName.AutoSize = true;
            this.chkDeleteFilesWithSameName.Location = new System.Drawing.Point(6, 20);
            this.chkDeleteFilesWithSameName.Name = "chkDeleteFilesWithSameName";
            this.chkDeleteFilesWithSameName.Size = new System.Drawing.Size(356, 17);
            this.chkDeleteFilesWithSameName.TabIndex = 0;
            this.chkDeleteFilesWithSameName.Text = "Files with same name but different extension (may not be same image!)";
            this.chkDeleteFilesWithSameName.UseVisualStyleBackColor = true;
            this.chkDeleteFilesWithSameName.CheckedChanged += new System.EventHandler(this.ChkDeleteFilesWithSameNameCheckedChanged);
            // 
            // btnMoveDirectory
            // 
            this.btnMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDirectory.Location = new System.Drawing.Point(299, 86);
            this.btnMoveDirectory.Name = "btnMoveDirectory";
            this.btnMoveDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnMoveDirectory.TabIndex = 4;
            this.btnMoveDirectory.Text = "...";
            this.btnMoveDirectory.UseVisualStyleBackColor = true;
            this.btnMoveDirectory.Click += new System.EventHandler(this.BtnMoveDirectoryClick);
            // 
            // txtMoveDirectory
            // 
            this.txtMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoveDirectory.Location = new System.Drawing.Point(6, 88);
            this.txtMoveDirectory.Name = "txtMoveDirectory";
            this.txtMoveDirectory.ReadOnly = true;
            this.txtMoveDirectory.Size = new System.Drawing.Size(287, 20);
            this.txtMoveDirectory.TabIndex = 3;
            this.txtMoveDirectory.TextChanged += new System.EventHandler(this.TxtMoveDirectoryTextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(906, 343);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "";
            // 
            // grdOutput
            // 
            this.grdOutput.AllowUserToAddRows = false;
            this.grdOutput.AllowUserToDeleteRows = false;
            this.grdOutput.AllowUserToResizeRows = false;
            this.grdOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Folder,
            this.OriginalImage,
            this.DuplicateFolder,
            this.DuplicateImage,
            this.OpenFolder,
            this.ViewImages});
            this.grdOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutput.Location = new System.Drawing.Point(3, 3);
            this.grdOutput.Name = "grdOutput";
            this.grdOutput.ReadOnly = true;
            this.grdOutput.Size = new System.Drawing.Size(906, 343);
            this.grdOutput.TabIndex = 0;
            this.grdOutput.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdOutputCellContentClick);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Width = 62;
            // 
            // Folder
            // 
            this.Folder.HeaderText = "Original Folder";
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            this.Folder.Width = 99;
            // 
            // OriginalImage
            // 
            this.OriginalImage.HeaderText = "Original Image";
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.ReadOnly = true;
            this.OriginalImage.Width = 99;
            // 
            // DuplicateFolder
            // 
            this.DuplicateFolder.HeaderText = "Duplicate Folder";
            this.DuplicateFolder.Name = "DuplicateFolder";
            this.DuplicateFolder.ReadOnly = true;
            this.DuplicateFolder.Width = 109;
            // 
            // DuplicateImage
            // 
            this.DuplicateImage.HeaderText = "Duplicate Image";
            this.DuplicateImage.Name = "DuplicateImage";
            this.DuplicateImage.ReadOnly = true;
            this.DuplicateImage.Width = 109;
            // 
            // OpenFolder
            // 
            this.OpenFolder.HeaderText = "Open Folder";
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.ReadOnly = true;
            this.OpenFolder.Text = "Open Folder";
            this.OpenFolder.UseColumnTextForButtonValue = true;
            this.OpenFolder.Width = 71;
            // 
            // ViewImages
            // 
            this.ViewImages.HeaderText = "View Images";
            this.ViewImages.Name = "ViewImages";
            this.ViewImages.ReadOnly = true;
            this.ViewImages.Text = "View Images";
            this.ViewImages.UseColumnTextForButtonValue = true;
            this.ViewImages.Width = 73;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGrid);
            this.tabControl1.Controls.Add(this.tabOutput);
            this.tabControl1.Location = new System.Drawing.Point(12, 252);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 375);
            this.tabControl1.TabIndex = 3;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.grdOutput);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(912, 349);
            this.tabGrid.TabIndex = 0;
            this.tabGrid.Text = "Grid";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.txtOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(912, 349);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // grpCleanupOptions
            // 
            this.grpCleanupOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCleanupOptions.Controls.Add(this.radMoveToUS);
            this.grpCleanupOptions.Controls.Add(this.radMove);
            this.grpCleanupOptions.Controls.Add(this.radDelete);
            this.grpCleanupOptions.Controls.Add(this.btnMoveDirectory);
            this.grpCleanupOptions.Controls.Add(this.radPreview);
            this.grpCleanupOptions.Controls.Add(this.txtMoveDirectory);
            this.grpCleanupOptions.Location = new System.Drawing.Point(587, 0);
            this.grpCleanupOptions.Name = "grpCleanupOptions";
            this.grpCleanupOptions.Size = new System.Drawing.Size(333, 184);
            this.grpCleanupOptions.TabIndex = 1;
            this.grpCleanupOptions.TabStop = false;
            this.grpCleanupOptions.Text = "Cleanup Options";
            // 
            // radMoveToUS
            // 
            this.radMoveToUS.AutoSize = true;
            this.radMoveToUS.Location = new System.Drawing.Point(6, 114);
            this.radMoveToUS.Name = "radMoveToUS";
            this.radMoveToUS.Size = new System.Drawing.Size(82, 17);
            this.radMoveToUS.TabIndex = 5;
            this.radMoveToUS.Text = "Move to US";
            this.radMoveToUS.UseVisualStyleBackColor = true;
            // 
            // radMove
            // 
            this.radMove.AutoSize = true;
            this.radMove.Location = new System.Drawing.Point(6, 65);
            this.radMove.Name = "radMove";
            this.radMove.Size = new System.Drawing.Size(52, 17);
            this.radMove.TabIndex = 2;
            this.radMove.Text = "Move";
            this.radMove.UseVisualStyleBackColor = true;
            this.radMove.CheckedChanged += new System.EventHandler(this.RadMoveCheckedChanged);
            // 
            // radDelete
            // 
            this.radDelete.AutoSize = true;
            this.radDelete.Location = new System.Drawing.Point(6, 42);
            this.radDelete.Name = "radDelete";
            this.radDelete.Size = new System.Drawing.Size(56, 17);
            this.radDelete.TabIndex = 1;
            this.radDelete.TabStop = true;
            this.radDelete.Text = "Delete";
            this.radDelete.UseVisualStyleBackColor = true;
            // 
            // radPreview
            // 
            this.radPreview.AutoSize = true;
            this.radPreview.Checked = true;
            this.radPreview.Location = new System.Drawing.Point(6, 19);
            this.radPreview.Name = "radPreview";
            this.radPreview.Size = new System.Drawing.Size(63, 17);
            this.radPreview.TabIndex = 0;
            this.radPreview.TabStop = true;
            this.radPreview.Text = "Preview";
            this.radPreview.UseVisualStyleBackColor = true;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.Controls.Add(this.grpOptions);
            this.pnlOptions.Controls.Add(this.grpCleanupOptions);
            this.pnlOptions.Location = new System.Drawing.Point(12, 59);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(920, 187);
            this.pnlOptions.TabIndex = 12;
            this.pnlOptions.Resize += new System.EventHandler(this.PnlOptionsResize);
            // 
            // txtImageDirectory
            // 
            this.txtImageDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageDirectory.Location = new System.Drawing.Point(15, 32);
            this.txtImageDirectory.Name = "txtImageDirectory";
            this.txtImageDirectory.ReadOnly = true;
            this.txtImageDirectory.Size = new System.Drawing.Size(884, 20);
            this.txtImageDirectory.TabIndex = 1;
            this.txtImageDirectory.TextChanged += new System.EventHandler(this.TxtImageDirectoryTextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.progressBar.Location = new System.Drawing.Point(12, 633);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(758, 23);
            this.progressBar.TabIndex = 4;
            // 
            // btnViewDiffs
            // 
            this.btnViewDiffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDiffs.Location = new System.Drawing.Point(776, 633);
            this.btnViewDiffs.Name = "btnViewDiffs";
            this.btnViewDiffs.Size = new System.Drawing.Size(75, 23);
            this.btnViewDiffs.TabIndex = 13;
            this.btnViewDiffs.Text = "View Images";
            this.btnViewDiffs.UseVisualStyleBackColor = true;
            this.btnViewDiffs.Click += new System.EventHandler(this.btnViewDiffs_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 668);
            this.Controls.Add(this.btnViewDiffs);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDirectorySelector);
            this.Controls.Add(this.txtImageDirectory);
            this.Controls.Add(this.lblImageDirectory);
            this.Controls.Add(this.btnGo);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Dup Image Deleter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutput)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGrid.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.grpCleanupOptions.ResumeLayout(false);
            this.grpCleanupOptions.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblImageDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox txtImageDirectory;
        private System.Windows.Forms.Button btnDirectorySelector;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.CheckBox chkDeleteFilesWithSameName;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.TextBox txtMoveDirectory;
        private System.Windows.Forms.Button btnMoveDirectory;
        private System.Windows.Forms.FolderBrowserDialog moveDirectoryBrowser;
        private System.Windows.Forms.DataGridView grdOutput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.CheckBox chkHashCheck;
        private System.Windows.Forms.CheckBox chkRequireLikeFileNames;
        private DupImageDeleter.TextProgressBar progressBar;
        private System.Windows.Forms.GroupBox grpCleanupOptions;
        private System.Windows.Forms.RadioButton radMove;
        private System.Windows.Forms.RadioButton radDelete;
        private System.Windows.Forms.RadioButton radPreview;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox chkPreferHigherResolution;
        private System.Windows.Forms.CheckBox chkSearchTopDirectoriesOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateImage;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFolder;
        private System.Windows.Forms.DataGridViewButtonColumn ViewImages;
        private System.Windows.Forms.RadioButton radMoveToUS;
        private System.Windows.Forms.CheckBox chkLikeFileNames;
        private System.Windows.Forms.CheckBox chkExcludeGameplay;
        private System.Windows.Forms.Button btnViewDiffs;
    }
}

