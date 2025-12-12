using FastRestorer.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace FastRestorer.Views
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Backup> Backups { get; } = new();

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
            var files = FH.SelectFiles("Backups (*.bak)|*.bak");
        }

        #endregion

        #region Private Methods

        #endregion
    }
}