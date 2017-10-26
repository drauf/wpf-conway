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
            switch ((CellType)value)
            {
                case CellType.NewAlive:
                    return 0;
                case CellType.Alive:
                    return 1;
                case CellType.NewDead:
                    return 2;
                case CellType.Dead:
                    return 3;
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
