using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Juice.Mobile.Framework.TypeConverters {

	public class MobileToleranceConverter : TypeConverter {

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
			if(destinationType == typeof(string)) {
				return true;
			}
			if(destinationType == typeof(InstanceDescriptor)) {
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
			return sourceType == typeof(string);
		}


		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

			if(value != null && value is String) {
				string[] parts = (value as String).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if(parts.Length == 0) {
					return null;
				}

				int[] values = ConvertArray(parts);

				var tolerance = new MobileTolerance() {
					Top = values.Length > 0 ? values[0] : 0,
					Right = values.Length > 1 ? values[1] : 0,
					Bottom = values.Length > 2 ? values[2] : 0,
					Left = values.Length > 3 ? values[3] : 0
				};

				return tolerance;
			}

			return null;
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
			if(value is MobileTolerance) {
				if(destinationType == typeof(string)) {
					value.ToString();
				}
				if(destinationType == typeof(InstanceDescriptor)) {
					MobileTolerance tolerance = value as MobileTolerance;
					ConstructorInfo constructor = typeof(MobileTolerance).GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) });
					InstanceDescriptor instance = new InstanceDescriptor(constructor, new object[] { tolerance.Top, tolerance.Right, tolerance.Bottom, tolerance.Left });
					return instance;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		private int[] ConvertArray(string[] arrayToConvert) {
			int[] resultingArray = new int[arrayToConvert.Length];

			int itemValue;

			resultingArray = Array.ConvertAll<string, int>
					(
							arrayToConvert,
							delegate(string intParameter) {
								int.TryParse(intParameter, out itemValue);
								return itemValue;
							}
					);

			return resultingArray;
		}
	}
}
