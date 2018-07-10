using System;
using System.Windows.Data;
using NationalInstruments.Controls;

namespace UI.TemperatureController.Converters
{
    public class BooleanToAdjusterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if ((bool)value == true)
                return RangeAdjuster.None;
            else if ((bool)value == false)
                return RangeAdjuster.FitLoosely;
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
