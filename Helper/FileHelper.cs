using Microsoft.Win32;

namespace FastRestorer.Helper
{
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
    }
}
