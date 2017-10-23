using System.Collections.ObjectModel;
using System.ComponentModel;
using Conway.Models;

namespace Conway.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly Grid _grid;
        private static readonly int Length = 20;
        private static readonly int Width = 20;

        public MainWindowViewModel()
        {
            _grid = new Grid(Length, Width);
            List = _grid.GetAsObservableCollection();
        }

        private int _generation;
        public int Generation
        {
            get => _generation;
            set
            {
                _generation = value;
                OnPropertyChanged("Generation");
            }
        }

        private ObservableCollection<ObservableCollection<CellDisplay>> _list;
        public ObservableCollection<ObservableCollection<CellDisplay>> List
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged("List");
            }
        }

        public void Generate(int jump)
        {
            while (jump-- > 0)
            {
                _grid.GenerateNextPopulation();
                List = _grid.GetAsObservableCollection();
                Generation++;
            }
        }

        public void ChangeCell(int index)
        {
            _grid.ChangeCell(index);
            List = _grid.GetAsObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
