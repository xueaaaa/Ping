using System.Globalization;
using System.Windows.Data;
using Ping.Models.Task;

namespace Ping.Converters
{
    internal class PriorityToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is Priority)
                return (int)(Priority)value;

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
