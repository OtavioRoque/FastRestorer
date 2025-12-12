using Microsoft.Win32;
using System.IO;

namespace FastRestorer.Helpers
{
    /// <summary>
    /// Provides utility methods for common file operations and validations.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Displays a file selection dialog that allows the user to select one or more files matching the specified filter.
        /// </summary>
        /// 
        /// <param name="filter">
        /// The file type filter string used to determine which files are displayed in the dialog.
        /// The format should follow 'Description|Extension', such as "Text files (*.txt)|*.txt".
        /// </param>
        /// 
        /// <returns>
        /// An array of strings containing the full paths of the selected files.
        /// Returns an empty array if no files are selected or the dialog is canceled.
        /// </returns>
        public static string[] SelectFiles(string filter = "All files (*.*)|*.*")
        {
            var dialog = new OpenFileDialog
            {
                Filter = filter,
                Multiselect = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            bool? result = dialog.ShowDialog();

            return result == true ? dialog.FileNames : Array.Empty<string>();
        }

        /// <summary>
        /// Determines whether the specified file path refers to an existing file with a .bak extension.
        /// </summary>
        /// 
        /// <param name="path">
        /// The file system path to check. Can be either an absolute or relative path.
        /// </param>
        /// 
        /// <returns>
        /// <see langword="true"/> if the file exists and has a .bak extension; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsBakFile(string path)
        {
            if (!File.Exists(path))
                return false;

            return Path.GetExtension(path).Equals(".bak", StringComparison.OrdinalIgnoreCase);
        }
    }
}
