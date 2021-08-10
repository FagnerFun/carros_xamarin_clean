using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace carros_xamarin_clean.Util.Converters
{
    public class ListToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            return value is ICollection<string> errors && errors.Count > 0 ? string.Join(Environment.NewLine, errors) : null;
        }

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
