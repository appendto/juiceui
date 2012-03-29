using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Juice.Framework.TypeConverters {

	/// <summary>
	/// Basically a 1-1 copy of the StringArrayConverter.
	/// Use case: Autocomplete's Source property can accept a string (specifying a url) or a string array (specifying data to use). We'd like to handle both in the same property.
	/// </summary>
	public class StringArrayConverter : TypeConverter {
		// Methods
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return (sourceType == typeof(string) || sourceType == typeof(ArrayList));
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			if(!(value is string)) {

				// JavascriptSerializer will transform arrays in json to ArrayList
				if(value is ArrayList) {
					ArrayList list = value as ArrayList;

					if(list != null) {
						return list.ToArray(typeof(string));
					}
				}
				throw base.GetConvertFromException(value);
			}
			if(((string)value).Length == 0) {
				return new string[0];
			}
			string[] strArray = ((string)value).Split(new char[] { ',' });
			for(int i = 0; i < strArray.Length; i++) {
				strArray[i] = strArray[i].Trim();
			}
			return strArray;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			if(!(destinationType == typeof(string))) {
				throw base.GetConvertToException(value, destinationType);
			}
			if(value == null) {
				return string.Empty;
			}
			return string.Join(",", (string[])value);
		}
	}
}
