using System;
using System.ComponentModel;

namespace Juice.Framework {

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class WidgetOptionAttribute : Attribute {
	
		public WidgetOptionAttribute(string name) {
			Name = name;
		}

		public WidgetOptionAttribute(string name, object defaultValue) {
			Name = name;
			DefaultValue = defaultValue;
		}

		public string Name { get; set; }
		public object DefaultValue { get; set; }
		public bool Eval { get; set; }
		
		// TODO: According to Scott, jQuery UI 2.0 will not use templates in the options. Remove this functionality when that arrives.
		[Obsolete("According to Scott, jQuery UI 2.0 will not use templates in the options. Remove this functionality when that arrives.")]
		public bool HtmlEncoding { get; set; }

		public WidgetOption GetWidgetOption(PropertyDescriptor propertyDescriptor) {
			return new WidgetOption(propertyDescriptor) {
				Name = Name,
				DefaultValue = DefaultValue,
				RequiresEval = Eval,
				HtmlEncoding = HtmlEncoding
			};
		}
	}
}