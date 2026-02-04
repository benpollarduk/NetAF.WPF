using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NetAF.Targets.WPF.Converters
{
    internal class CommandHelpToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (bool.TryParse(value?.ToString() ?? string.Empty, out var boolValue))
                return boolValue ? Visibility.Visible : Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
