using System.Windows;
using System.Windows.Controls;
using Conway.Models;
using Conway.ViewModels;

namespace Conway.Views
{
    public partial class MainWindow
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(75, 50);
            DataContext = _viewModel;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Generate(GenerationJump.Value.GetValueOrDefault(1));
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            var index = (int)((Button)sender).Tag;
            _viewModel.ChangeCell(index);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            var newGameDialog = new NewGameDialog();
            if (newGameDialog.ShowDialog() == true)
            {
                _viewModel = new MainWindowViewModel(int.Parse(newGameDialog.X), int.Parse(newGameDialog.Y));
                DataContext = _viewModel;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            var slot = menuItem.DataContext as LoadSaveSlot;

            _viewModel.SaveGame(slot.Id);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            var slot = menuItem.DataContext as LoadSaveSlot;

            _viewModel.LoadGame(slot.Id);
        }
    }
}
