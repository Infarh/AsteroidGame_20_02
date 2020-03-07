using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BindingTestsApp.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bool_value = System.Convert.ToBoolean(value);
            if (bool_value)
                return Visibility.Visible;
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)System.Convert.ChangeType(value, typeof(Visibility));
            switch (visibility)
            {
                default: throw new NotSupportedException($"Значение {visibility} не поддерживается");
                case Visibility.Visible: return true;
                case Visibility.Hidden: return false;
            }
        }
    }
}
