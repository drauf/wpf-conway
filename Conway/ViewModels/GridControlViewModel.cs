using System.Collections.ObjectModel;
using System.ComponentModel;
using Conway.Models;
using Conway.Service;

namespace Conway.ViewModels
{
    public class GridControlViewModel : INotifyPropertyChanged
    {
        private readonly Grid _grid;

        public GridControlViewModel(int width, int length)
        {
            _grid = new Grid(width, length);
            List = _grid.GetAsObservableCollection();
        }

        private ObservableCollection<ObservableCollection<Cell>> _list;
        public ObservableCollection<ObservableCollection<Cell>> List
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
                _grid.UpdateObservableCollection(List);
            }
        }

        public void ChangeCell(int index)
        {
            _grid.ChangeCell(index);
            _grid.UpdateObservableCollection(List);
        }

        public void NewGame(int width, int height)
        {
            _grid.GenerateNewGrid(width, height);
            List = _grid.GetAsObservableCollection();
        }

        public void LoadGame(int slot)
        {
            if (LoadSaveService.IsEmpty(slot)) return;

            _grid.State = LoadSaveService.Load(slot);
            List = _grid.GetAsObservableCollection();
        }

        public void SaveGame(int slot)
        {
            LoadSaveService.Save(slot, _grid.State);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
