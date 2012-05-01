using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Juice.Framework.TypeConverters {

	public class AutocompleteListConverter : TypeConverter {

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return sourceType == typeof(string);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

			if(value == null) {
				return null;
			}

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<AutocompleteItem>));
			List<AutocompleteItem> result = null;

			try {

				using(MemoryStream ms = new MemoryStream(System.Text.Encoding.Unicode.GetBytes(value as String))) {
					result = serializer.ReadObject(ms) as List<AutocompleteItem>;
				}

				return result;
			}
			catch(System.Runtime.Serialization.SerializationException) {
				return null;
			}
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			if(value == null) {
				return null;
			}

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<AutocompleteItem>));

			try {

				using(MemoryStream ms = new MemoryStream()) {
					serializer.WriteObject(ms, value);
					return System.Text.Encoding.Default.GetString(ms.ToArray());
				}
			}
			catch(System.Runtime.Serialization.SerializationException) {
				return null;
			}
		}
	}
}
