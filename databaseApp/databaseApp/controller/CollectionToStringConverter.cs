using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace DatabaseApp.Controller
{
    public class CollectionToStringConverter : IValueConverter
    {
        // TODO: Upravit na smyslu plnější kód
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable collection)
                return string.Join(", ", collection).Split(",").Length + 1;
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
