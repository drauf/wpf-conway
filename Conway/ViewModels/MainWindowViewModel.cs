using System.Collections.Generic;
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

        public List<LoadSaveSlot> SaveSlots { get; }
        public List<LoadSaveSlot> LoadSlots { get; }

        public MainWindowViewModel()
        {
            SaveSlots = new List<LoadSaveSlot>();
            LoadSlots = new List<LoadSaveSlot>();
            for (var id = 1; id <= LoadSaveState.LoadSaveSlots; id++)
            {
                SaveSlots.Add(new LoadSaveSlot { Id = id, Name = $"Save {id}" });
                LoadSlots.Add(new LoadSaveSlot { Id = id, Name = $"Load {id}" });
            }

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

        public void SaveGame(int slot)
        {
            LoadSaveState.Save(slot, _grid.State);
        }

        public void LoadGame(int slot)
        {
            if (LoadSaveState.IsEmpty(slot)) return;

            _grid.State = LoadSaveState.Load(slot);
            List = _grid.GetAsObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
