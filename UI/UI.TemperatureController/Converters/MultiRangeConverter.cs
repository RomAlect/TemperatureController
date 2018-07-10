using NationalInstruments.Controls;
using System.Windows.Data;

namespace UI.TemperatureController.Converters
{
    public class MultiRangeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(System.Convert.ToDouble(values[0]) < System.Convert.ToDouble(values[1]))
            {
                return new Range<double>(System.Convert.ToDouble(values[0]),
                                 System.Convert.ToDouble(values[1]));
            }
            else
                return new Range<double>(0, 10);

        }

        public object[] ConvertBack(object value, System.Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
