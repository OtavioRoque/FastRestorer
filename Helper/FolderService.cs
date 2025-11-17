using Microsoft.Win32;

namespace FastRestorer.Helper
{
    public static class FolderService
    {
        /// <summary>
        /// Displays a dialog that allows the user to select a folder and returns the selected folder's path.
        /// </summary>
        /// <param name="title">The title to display in the folder selection dialog. If null or empty, a default title may be used.</param>
        /// <returns>The full path of the folder selected by the user. Returns null if the user cancels the dialog or no folder
        /// is selected.</returns>
        public static string SelectFolder(string title)
        {
            var dialog = new OpenFolderDialog()
            {
                Title = title
            };

            dialog.ShowDialog();

            return dialog.FolderName;
        }
    }
}
