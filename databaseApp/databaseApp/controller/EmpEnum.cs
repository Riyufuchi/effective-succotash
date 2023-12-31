using DatabaseApp.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DatabaseApp.Controller
{
    public class EmpEnum : IValueConverter
    {
        // TODO: Upravit na smyslu plnější kód
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<Employee> employees)
                return string.Join(", ", employees.Select(employee => (employee.FirstName + " " + employee.LastName)));
            return "No emloyees";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
