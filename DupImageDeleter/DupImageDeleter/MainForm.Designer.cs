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
            this.txtImageDirectory = new System.Windows.Forms.TextBox();
            this.btnDirectorySelector = new System.Windows.Forms.Button();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.btnMoveDirectory = new System.Windows.Forms.Button();
            this.chkMoveInsteadOfDelete = new System.Windows.Forms.CheckBox();
            this.txtMoveDirectory = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkDeleteFilesWithSameName = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.moveDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(397, 326);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
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
            // txtImageDirectory
            // 
            this.txtImageDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageDirectory.Location = new System.Drawing.Point(15, 32);
            this.txtImageDirectory.Name = "txtImageDirectory";
            this.txtImageDirectory.ReadOnly = true;
            this.txtImageDirectory.Size = new System.Drawing.Size(424, 20);
            this.txtImageDirectory.TabIndex = 1;
            this.txtImageDirectory.TextChanged += new System.EventHandler(this.txtImageDirectory_TextChanged);
            // 
            // btnDirectorySelector
            // 
            this.btnDirectorySelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectorySelector.Location = new System.Drawing.Point(445, 30);
            this.btnDirectorySelector.Name = "btnDirectorySelector";
            this.btnDirectorySelector.Size = new System.Drawing.Size(27, 23);
            this.btnDirectorySelector.TabIndex = 2;
            this.btnDirectorySelector.Text = "...";
            this.btnDirectorySelector.UseVisualStyleBackColor = true;
            this.btnDirectorySelector.Click += new System.EventHandler(this.btnDirectorySelector_Click);
            // 
            // chkTestMode
            // 
            this.chkTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(314, 330);
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
            this.grpOptions.Controls.Add(this.btnMoveDirectory);
            this.grpOptions.Controls.Add(this.chkMoveInsteadOfDelete);
            this.grpOptions.Controls.Add(this.txtMoveDirectory);
            this.grpOptions.Controls.Add(this.lblExtension);
            this.grpOptions.Controls.Add(this.txtExtension);
            this.grpOptions.Controls.Add(this.chkDeleteFilesWithSameName);
            this.grpOptions.Location = new System.Drawing.Point(12, 59);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(460, 79);
            this.grpOptions.TabIndex = 3;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // btnMoveDirectory
            // 
            this.btnMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDirectory.Location = new System.Drawing.Point(427, 44);
            this.btnMoveDirectory.Name = "btnMoveDirectory";
            this.btnMoveDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnMoveDirectory.TabIndex = 5;
            this.btnMoveDirectory.Text = "...";
            this.btnMoveDirectory.UseVisualStyleBackColor = true;
            this.btnMoveDirectory.Click += new System.EventHandler(this.btnMoveDirectory_Click);
            // 
            // chkMoveInsteadOfDelete
            // 
            this.chkMoveInsteadOfDelete.AutoSize = true;
            this.chkMoveInsteadOfDelete.Location = new System.Drawing.Point(6, 48);
            this.chkMoveInsteadOfDelete.Name = "chkMoveInsteadOfDelete";
            this.chkMoveInsteadOfDelete.Size = new System.Drawing.Size(185, 17);
            this.chkMoveInsteadOfDelete.TabIndex = 3;
            this.chkMoveInsteadOfDelete.Text = "Move duplicates instead of delete";
            this.chkMoveInsteadOfDelete.UseVisualStyleBackColor = true;
            this.chkMoveInsteadOfDelete.CheckedChanged += new System.EventHandler(this.chkMoveInsteadOfDelete_CheckedChanged);
            // 
            // txtMoveDirectory
            // 
            this.txtMoveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoveDirectory.Location = new System.Drawing.Point(197, 46);
            this.txtMoveDirectory.Name = "txtMoveDirectory";
            this.txtMoveDirectory.ReadOnly = true;
            this.txtMoveDirectory.Size = new System.Drawing.Size(224, 20);
            this.txtMoveDirectory.TabIndex = 4;
            this.txtMoveDirectory.TextChanged += new System.EventHandler(this.txtMoveDirectory_TextChanged);
            // 
            // lblExtension
            // 
            this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(280, 21);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(99, 13);
            this.lblExtension.TabIndex = 1;
            this.lblExtension.Text = "Extension to Delete";
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtension.Location = new System.Drawing.Point(385, 18);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(69, 20);
            this.txtExtension.TabIndex = 2;
            this.txtExtension.TextChanged += new System.EventHandler(this.txtExtension_TextChanged);
            // 
            // chkDeleteFilesWithSameName
            // 
            this.chkDeleteFilesWithSameName.AutoSize = true;
            this.chkDeleteFilesWithSameName.Location = new System.Drawing.Point(6, 20);
            this.chkDeleteFilesWithSameName.Name = "chkDeleteFilesWithSameName";
            this.chkDeleteFilesWithSameName.Size = new System.Drawing.Size(233, 17);
            this.chkDeleteFilesWithSameName.TabIndex = 0;
            this.chkDeleteFilesWithSameName.Text = "Files with same name but different extension";
            this.chkDeleteFilesWithSameName.UseVisualStyleBackColor = true;
            this.chkDeleteFilesWithSameName.CheckedChanged += new System.EventHandler(this.chkDeleteFilesWithSameName_CheckedChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 144);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(460, 176);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.chkTestMode);
            this.Controls.Add(this.btnDirectorySelector);
            this.Controls.Add(this.txtImageDirectory);
            this.Controls.Add(this.lblImageDirectory);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dup Image Deleter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
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
    }
}

