using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace TestingSignalR.Converters
{
	public class ChgConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//kane convert to value pou einai string se int!!!
			//string s1 = value.ToString();
			var s1 = value.ToString();
			var s2 = s1.Substring(0,s1.Length-1);

			var s = double.Parse(s2,System.Globalization.CultureInfo.InvariantCulture);
			if (s >= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
