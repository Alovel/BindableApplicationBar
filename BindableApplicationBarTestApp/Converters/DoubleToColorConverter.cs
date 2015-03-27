using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media;

namespace BindableApplicationBar.TestApp.Converters
{
    public class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter as string == "name")
            {
                var values = GetWeirdEnumNames<Colors>();
                var input = (double)value;
                return values[(int)(input * values.Length)];
            }
            else
            {
                var values = GetWeirdEnumValues<Colors, Color>();
                var input = (double) value;
                return values[(int) (input*values.Length)];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public static T2[] GetWeirdEnumValues<T1,T2>()
        {
            var type = typeof(T1);

            return
                (from property in type.GetProperties(BindingFlags.Public | BindingFlags.Static)
                select (T2)property.GetValue(null, null)).ToArray();
        }

        public static string[] GetWeirdEnumNames<T>()
        {
            var type = typeof(T);

            return
                (from property in type.GetProperties(BindingFlags.Public | BindingFlags.Static)
                select property.Name).ToArray();
        }
    }
}
