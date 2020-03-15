// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageViewerForm.cs" company="">
//
// </copyright>
// <summary>
//   The image viewer form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DupImageDeleter
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    ///     The image viewer form.
    /// </summary>
    public partial class ImageViewerForm : Form
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageViewerForm" /> class.
        /// </summary>
        public ImageViewerForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Gets or sets the original image path.
        /// </summary>
        public string OriginalImagePath { get; set; }

        /// <summary>
        ///     Gets or sets the dup image path.
        /// </summary>
        public string DupImagePath { get; set; }

        /// <summary>
        /// The image viewer form_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ImageViewerFormLoad(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.OriginalImagePath;
            this.pictureBox2.ImageLocation = this.DupImagePath;

            this.lblOriginal.Text = $"Original Image: {this.pictureBox1.ImageLocation}";
            this.lblDuplicate.Text = $"Duplicate Image: { this.pictureBox2.ImageLocation}";
        }

        private void btnDeleteLeft_Click(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(this.pictureBox1.ImageLocation);
            f.Delete();
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnDeleteRight_Click(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(this.pictureBox2.ImageLocation);
            f.Delete();
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}