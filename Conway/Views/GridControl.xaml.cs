using System.Windows;
using System.Windows.Controls;
using Conway.ViewModels;

namespace Conway.Views
{
    public partial class GridControl
    {
        private readonly GridControlViewModel _viewModel;

        public GridControl()
        {
            InitializeComponent();
            _viewModel = new GridControlViewModel(75, 50);
            DataContext = _viewModel;
        }

        public void Generate(int jump)
        {
            _viewModel.Generate(jump);
        }

        public void NewGame(int width, int height)
        {
            _viewModel.NewGame(width, height);
        }

        public void LoadGame(int slotId)
        {
            _viewModel.LoadGame(slotId);
        }

        public void SaveGame(int slotId)
        {
            _viewModel.SaveGame(slotId);
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            var index = (int) ((Button)sender).Tag;
            _viewModel.ChangeCell(index);
        }
    }
}
