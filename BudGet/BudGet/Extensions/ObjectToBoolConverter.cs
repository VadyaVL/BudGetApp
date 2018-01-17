using System;
using System.Globalization;
using Xamarin.Forms;

namespace BudGet.Extensions
{
    /// <summary>
    /// Converting an object to a boolean value.
    /// Checking the object is not empty.
    /// Etc...
    /// </summary>
    public class ObjectToBoolConverter : IValueConverter
    {
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Boolean value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return !string.IsNullOrWhiteSpace(str);
            }

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
