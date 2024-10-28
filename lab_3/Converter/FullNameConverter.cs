using lab_3.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace lab_3.Converter
{
    public class FullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Customer customer)
            {
                return $"{customer.FirstName} {customer.LastName}";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
