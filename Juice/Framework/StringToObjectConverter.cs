using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Juice.Framework {

	public class StringToObjectConverter : TypeConverter {
		public override bool IsValid(ITypeDescriptorContext context, object value) {
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			if(sourceType == typeof(string)) {
				return true;
			}

			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
			if(destinationType == typeof(object)) {
				return true;
			}

			if(destinationType == typeof(InstanceDescriptor)) {
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			return value.ToString();
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {

			if(destinationType == typeof(object)) {
				return (object)value;
			}

			if(destinationType == typeof(InstanceDescriptor)) {
				bool result;

				if(bool.TryParse(value.ToString(), out result)) {

					return new InstanceDescriptor(typeof(bool).GetMethod("Parse"), new object[] { value });
				}
				else if(value.GetType() == typeof(String)) {
					return new InstanceDescriptor(typeof(String).GetMethod("Copy"), new object[] { value });
				}
				else {
					return new InstanceDescriptor(typeof(object).GetConstructor(new Type[] { }), new object[] { });
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
