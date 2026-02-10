using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NetAF.Targets.WPF.Converters
{
    internal class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double d ? new GridLength(d) : new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is GridLength gl ? gl.Value : 0.0;
        }
    }
}
