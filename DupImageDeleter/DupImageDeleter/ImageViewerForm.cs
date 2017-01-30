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
        /// Gets or sets the dup image path.
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

            this.lblOriginal.Text = this.pictureBox1.ImageLocation;
            this.lblDuplicate.Text = this.pictureBox2.ImageLocation;
        }
    }
}