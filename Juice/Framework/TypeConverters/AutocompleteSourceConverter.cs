using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Juice.Framework.TypeConverters {

	public class AutocompleteSourceConverter : TypeConverter {

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return sourceType == typeof(string) || sourceType == typeof(ArrayList);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

			if(value == null) {
				return null;
			}
			
			if(value.GetType() == typeof(ArrayList)) {
				List<object> list = new List<object>();
				foreach(var o in value as ArrayList) {
					list.Add(o);
				}

				// regular string array
				if(list[0].GetType() == typeof(string)){
					return base.ConvertFrom(context, culture, value);
				}

				// janky deserialized array of dictionaries
				if(list[0].GetType() == typeof(Dictionary<String, object>)) {
					List<AutocompleteItem> result = new List<AutocompleteItem>();

					foreach(Dictionary<String, object> dict in list) {
						result.Add(new AutocompleteItem() {
							Label = dict["label"] as String,
							Value = dict["value"] as String
						});
					}

					return result;
				}
			}

			if(value.GetType() == typeof(string)) {
				AutocompleteListConverter converter = new AutocompleteListConverter();
				List<AutocompleteItem> list = converter.ConvertFromString(value as String) as List<AutocompleteItem>;

				if(list == null) {
					return base.ConvertFrom(context, culture, value);
				}
				else {
					return list;
				}
			}
			else {
				return base.ConvertFrom(context, culture, value);
			}
		}

	}
}
