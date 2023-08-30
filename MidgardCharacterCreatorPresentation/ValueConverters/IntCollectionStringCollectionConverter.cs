using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MidgardCharacterCreatorPresentation.ValueConverters
{
	[ValueConversion(typeof(int), typeof(string))]
	public class IntCollectionStringCollectionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ICollection<string> convertedList = new List<string>();
			foreach (int item in (ICollection<int>)value)
			{
				convertedList.Add(item.ToString());
			}

			return convertedList;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
	}
}
