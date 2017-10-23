using System;
using System.Windows.Data;
using System.Windows.Media;
using Conway.Enums;
using Conway.Models;

namespace Conway
{
    public class CellDisplayToColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            switch (((CellDisplay)value).Type)
            {
                case CellType.NewAlive:
                    return Brushes.Aquamarine;
                case CellType.Alive:
                    return Brushes.Chartreuse;
                case CellType.NewDead:
                    return Brushes.DarkOrchid;
                case CellType.Dead:
                    return Brushes.WhiteSmoke;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
