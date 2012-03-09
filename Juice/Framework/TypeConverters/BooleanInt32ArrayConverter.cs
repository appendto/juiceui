using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;

namespace Juice.Framework.TypeConverters {

	/// <summary>
	/// Because the tabs widget allows disabled to be either boolean or an array of ints, this is necessary.
	/// This is really a one-time case specifically for the tabs widget. 
	/// No other jQuery UI widgets double up on the disabled option.
	/// </summary>
	public class BooleanInt32ArrayConverter : TypeConverter {

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
			if(destinationType == typeof(string)) {
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			if(sourceType == typeof(string)) {
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			var stringValue = value as String;
			Boolean result;

			if(bool.TryParse(stringValue, out result)) {
				return new InstanceDescriptor(typeof(bool).GetMethod("Parse"), new object[] { value });
			}

			if(stringValue != null) {
				if(stringValue.StartsWith("[")) {
					stringValue = stringValue.Substring(1);
				}

				if(stringValue.EndsWith("]")) {
					stringValue = stringValue.Substring(0, stringValue.Length - 1);
				}

				return stringValue
										.Split(new[] { ',' })
										.Select(s => int.Parse(s, CultureInfo.InvariantCulture))
										.ToArray();
			}

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			if(destinationType == typeof(string)) {
				var intValue = value as int[];
				return string.Join(",", intValue.Select(i => i.ToString(CultureInfo.InvariantCulture)));
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
