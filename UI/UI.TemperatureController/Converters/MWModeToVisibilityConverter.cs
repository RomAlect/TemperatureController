using System;
using System.Globalization;
using System.Windows.Data;

namespace UI.TemperatureController.Converters
{
    public class MWModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((string)value == "Frequency Sweep")
                return System.Windows.Visibility.Visible;
            else
                return
                    System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
