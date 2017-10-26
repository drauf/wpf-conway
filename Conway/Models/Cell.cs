using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Conway.Annotations;
using Conway.Enums;

namespace Conway.Models
{
    [Serializable]
    public class Cell : INotifyPropertyChanged
    {
        public int Index { get; set; }
        public int NumberOfNeighbours { get; set; }

        private CellType _type;
        public CellType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public bool IsAlive() => Type == CellType.Alive || Type == CellType.NewAlive;

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
