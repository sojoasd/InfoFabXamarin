using System;
using System.Globalization;
using Xamarin.Forms;

namespace InfoFabApp
{
	public class FavoriteBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//if (!(value is bool)) return "\uf08a";
			//return (bool)value ? "\uf004" : "\uf08a";

			//if (!(value is bool)) return "False";
			//return (bool)value ? "True" : "False";

			if (!(value is bool)) return "False";
			return (bool)value ? "\uf004" : "\uf08a";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is string)) return "\uf08a";
			return (string)value == "True" ? "\uf004" : "\uf08a";
		}
	}
}
