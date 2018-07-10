using System;
using System.Windows.Data;

namespace UI.TemperatureController.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
                return System.Windows.Visibility.Visible;
            else if ((bool)value == false)
                return System.Windows.Visibility.Collapsed;
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
