using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Juice.Framework.TypeConverters {

	public class JsonObjectConverter : TypeConverter {
		public override bool IsValid(ITypeDescriptorContext context, object value) {
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return true; // anything can be serialized!
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
			if(destinationType == typeof(string)) {
				return true;
			}

			if(destinationType == typeof(InstanceDescriptor)) {
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
			if(value == null) {
				return null;
			}
			
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			return value == null ? null : value.ToString();
		}
	}
}
