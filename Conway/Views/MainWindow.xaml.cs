using System.Windows;
using System.Windows.Controls;
using Conway.Models;
using Conway.ViewModels;

namespace Conway.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GridControl.Generate(GenerationJump.Value.GetValueOrDefault(1));
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var newGameDialog = new NewGameDialog();
            if (newGameDialog.ShowDialog() == true)
            {
                GridControl.NewGame(int.Parse(newGameDialog.X), int.Parse(newGameDialog.Y));
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            if (menuItem?.DataContext is LoadSaveSlot slot) GridControl.LoadGame(slot.Id);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            if (menuItem?.DataContext is LoadSaveSlot slot) GridControl.SaveGame(slot.Id);
        }
    }
}
