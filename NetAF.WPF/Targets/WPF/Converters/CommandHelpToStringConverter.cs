using NetAF.Commands;
using System.Globalization;
using System.Windows.Data;

namespace NetAF.Targets.WPF.Converters
{
    internal class PromptToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Prompt prompt)
                return prompt.Entry;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
