using System.Windows;
using System.Windows.Controls;
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
    }
}
