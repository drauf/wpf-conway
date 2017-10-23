using System.Windows;
using System.Windows.Controls;
using Conway.Models;
using Conway.ViewModels;

namespace Conway.Views
{
    public partial class MainWindow
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
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
