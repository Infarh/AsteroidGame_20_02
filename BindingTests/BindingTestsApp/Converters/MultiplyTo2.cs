using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BindingTestsApp.Converters
{
    class MultiplyTo2 : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            var x = System.Convert.ToDouble(value);
            return x * 2;
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            var y = System.Convert.ToDouble(value);
            var x = y / 2;
            return System.Convert.ChangeType(x, type);
        }
    }
}
