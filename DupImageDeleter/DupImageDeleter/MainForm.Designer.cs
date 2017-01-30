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
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkRequireLikeFileNames = new System.Windows.Forms.CheckBox();
            this.chkHashCheck = new System.Windows.Forms.CheckBox();
            this.btnMoveDirectory = new System.Windows.Forms.Button();
            this.chkMoveInsteadOfDelete = new System.Windows.Forms.CheckBox();
            this.txtMoveDirectory = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkDeleteFilesWithSameName = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.moveDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grdOutput = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuplicateImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFolder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewImages = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.txtImageDirectory = new System.Windows.Forms.TextBox();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutput)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGrid.SuspendLayout();
            this.tabOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(497, 497);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
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
            this.btnDirectorySelector.Location = new System.Drawing.Point(545, 30);
            this.btnDirectorySelector.Name = "btnDirectorySelector";
            this.btnDirectorySelector.Size = new System.Drawing.Size(27, 23);
            this.btnDirectorySelector.TabIndex = 2;
            this.btnDirectorySelector.Text = "...";
            this.btnDirectorySelector.UseVisualStyleBackColor = true;
            this.btnDirectorySelector.Click += new System.EventHandler(this.BtnDirectorySelectorClick);
            // 
            // chkTestMode
            // 
            this.chkTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(414, 501);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(77, 17);
            this.chkTestMode.TabIndex = 5;
            this.chkTestMode.Text = "Test Mode";
            this.chkTestMode.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.Controls.Add(this.chkRequireLikeFileNames);
            this.grpOptions.Controls.Add(this.chkHashCheck);
            this.grpOptions.Controls.Add(this.btnMoveDirectory);
            this.grpOptions.Controls.Add(this.chkMoveInsteadOfDelete);
            this.grpOptions.Controls.Add(this.txtMoveDirectory);
            this.grpOptions.Controls.Add(this.lblExtension);
            this.grpOptions.Controls.Add(this.txtExtension);
            this.grpOptions.Controls.Add(this.chkDeleteFilesWithSameName);
            this.grpOptions.Location = new System.Drawing.Point(12, 59);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(560, 99);
            this.grpOptions.TabIndex = 3;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkRequireLikeFileNames
            // 
            this.chkRequireLikeFileNames.AutoSize = true;
            this.chkRequireLikeFileNames.Location = new System.Drawing.Point(197, 46);
            this.chkRequireLikeFileNames.Name = "chkRequireLikeFileNames";
            this.chkRequireLikeFileNames.Size = new System.Drawing.Size(259, 17);
            this.chkRequireLikeFileNames.TabIndex = 7;
            this.chkRequireLikeFileNames.Text = "Require Like File Names (i.e. Game-01, Game-02)";
            this.chkRequireLikeFileNames.UseVisualStyleBackColor = true;
            // 
            // chkHashCheck
            // 
            this.chkHashCheck.AutoSize = true;
            this.chkHashCheck.Location = new System.Drawing.Point(6, 46);
            this.chkHashCheck.Name = "chkHashCheck";
            this.chkHashCheck.Size = new System.Drawing.Size(125, 17);
            this.chkHashCheck.TabIndex = 6;
            this.chkHashCheck.Text = "Files with same Hash";
            this.chkHashCheck.UseVisualStyleBackColor = true;
            this.chkHashCheck.CheckedChanged += new System.EventHandler(this.ChkHashCheckCheckedChanged);
            // 
            // btnMoveDirectory
            // 
            this.btnMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDirectory.Location = new System.Drawing.Point(527, 68);
            this.btnMoveDirectory.Name = "btnMoveDirectory";
            this.btnMoveDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnMoveDirectory.TabIndex = 5;
            this.btnMoveDirectory.Text = "...";
            this.btnMoveDirectory.UseVisualStyleBackColor = true;
            this.btnMoveDirectory.Click += new System.EventHandler(this.BtnMoveDirectoryClick);
            // 
            // chkMoveInsteadOfDelete
            // 
            this.chkMoveInsteadOfDelete.AutoSize = true;
            this.chkMoveInsteadOfDelete.Location = new System.Drawing.Point(6, 72);
            this.chkMoveInsteadOfDelete.Name = "chkMoveInsteadOfDelete";
            this.chkMoveInsteadOfDelete.Size = new System.Drawing.Size(185, 17);
            this.chkMoveInsteadOfDelete.TabIndex = 3;
            this.chkMoveInsteadOfDelete.Text = "Move duplicates instead of delete";
            this.chkMoveInsteadOfDelete.UseVisualStyleBackColor = true;
            this.chkMoveInsteadOfDelete.CheckedChanged += new System.EventHandler(this.ChkMoveInsteadOfDeleteCheckedChanged);
            // 
            // txtMoveDirectory
            // 
            this.txtMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoveDirectory.Location = new System.Drawing.Point(197, 70);
            this.txtMoveDirectory.Name = "txtMoveDirectory";
            this.txtMoveDirectory.ReadOnly = true;
            this.txtMoveDirectory.Size = new System.Drawing.Size(324, 20);
            this.txtMoveDirectory.TabIndex = 4;
            this.txtMoveDirectory.TextChanged += new System.EventHandler(this.TxtMoveDirectoryTextChanged);
            // 
            // lblExtension
            // 
            this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(380, 21);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(93, 13);
            this.lblExtension.TabIndex = 1;
            this.lblExtension.Text = "Extension to Keep";
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtension.Location = new System.Drawing.Point(485, 18);
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
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(546, 295);
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
            this.DuplicateImage,
            this.OpenFolder,
            this.ViewImages});
            this.grdOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutput.Location = new System.Drawing.Point(3, 3);
            this.grdOutput.Name = "grdOutput";
            this.grdOutput.ReadOnly = true;
            this.grdOutput.Size = new System.Drawing.Size(546, 295);
            this.grdOutput.TabIndex = 7;
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
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            this.Folder.Width = 61;
            // 
            // OriginalImage
            // 
            this.OriginalImage.HeaderText = "Original Image";
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.ReadOnly = true;
            this.OriginalImage.Width = 99;
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
            this.tabControl1.Location = new System.Drawing.Point(12, 164);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 327);
            this.tabControl1.TabIndex = 9;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.grdOutput);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrid.Size = new System.Drawing.Size(552, 301);
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
            this.tabOutput.Size = new System.Drawing.Size(552, 301);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // txtImageDirectory
            // 
            this.txtImageDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageDirectory.Location = new System.Drawing.Point(15, 32);
            this.txtImageDirectory.Name = "txtImageDirectory";
            this.txtImageDirectory.ReadOnly = true;
            this.txtImageDirectory.Size = new System.Drawing.Size(524, 20);
            this.txtImageDirectory.TabIndex = 1;
            this.txtImageDirectory.Text = global::DupImageDeleter.Properties.Settings.Default.ImageDirectory;
            this.txtImageDirectory.TextChanged += new System.EventHandler(this.TxtImageDirectoryTextChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 532);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.chkTestMode);
            this.Controls.Add(this.btnDirectorySelector);
            this.Controls.Add(this.txtImageDirectory);
            this.Controls.Add(this.lblImageDirectory);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 500);
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
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblImageDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox txtImageDirectory;
        private System.Windows.Forms.Button btnDirectorySelector;
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.CheckBox chkDeleteFilesWithSameName;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.TextBox txtMoveDirectory;
        private System.Windows.Forms.Button btnMoveDirectory;
        private System.Windows.Forms.CheckBox chkMoveInsteadOfDelete;
        private System.Windows.Forms.FolderBrowserDialog moveDirectoryBrowser;
        private System.Windows.Forms.DataGridView grdOutput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.TabPage tabOutput;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.CheckBox chkHashCheck;
        private System.Windows.Forms.CheckBox chkRequireLikeFileNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuplicateImage;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFolder;
        private System.Windows.Forms.DataGridViewButtonColumn ViewImages;
    }
}

