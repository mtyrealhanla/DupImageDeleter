// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAttribute.cs" company="">
//
// </copyright>
// <summary>
//   The file attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DupImageDeleter
{
    using System.IO;

    /// <summary>
    /// The file attribute.
    /// </summary>
    public sealed class FileAttribute
    {
        /// <summary>
        ///     Gets or sets the file info.
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        ///     Gets or sets the like file name.
        /// </summary>
        public string LikeFileName { get; set; }

        /// <summary>
        ///     Gets or sets the file name without extension.
        /// </summary>
        public string FileNameWithoutExtension { get; set; }

        /// <summary>
        ///     Gets or sets the file hash.
        /// </summary>
        public string FileHash { get; set; }

        /// <summary>
        /// Gets or sets the resolution.
        /// </summary>
        public int Resolution { get; set; }
    }
}