// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAttributeOutput.cs" company="">
//
// </copyright>
// <summary>
//   The file attribute output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DupImageDeleter
{
    /// <summary>
    /// The file attribute output.
    /// </summary>
    public sealed class FileAttributeOutput
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