using System.ComponentModel;
using System.Runtime.CompilerServices;
using Conway.Annotations;
using Conway.Enums;

namespace Conway.Models
{
    public class CellDisplay : INotifyPropertyChanged
    {
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

        public int Index { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
