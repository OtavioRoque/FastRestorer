using FastRestorer.Helper;
using System.Windows;

namespace FastRestorer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events

        private void GridDropArea_Drop(object sender, DragEventArgs e)
        {

        }

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var files = FileHelper.SelectFiles("Backups (*.zip;*.bak)|*.zip;*.bak");
        }

        #endregion
    }
}