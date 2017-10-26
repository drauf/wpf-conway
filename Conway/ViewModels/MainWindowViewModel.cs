using System.Collections.Generic;
using System.ComponentModel;
using Conway.Models;
using Conway.Service;

namespace Conway.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public static List<LoadSaveSlot> LoadSlots => LoadSaveService.LoadSlots;
        public static List<LoadSaveSlot> SaveSlots => LoadSaveService.SaveSlots;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
