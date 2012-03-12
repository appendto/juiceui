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

		/// <summary>
		/// The jQuery UI name of the option.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The default value of this option. This is used to determine if the option should be rendered to the page.
		/// </summary>
		public object DefaultValue { get; set; }

		/// <summary>
		/// True, if the option's value should be evaluated on the client when juice.js is initializing the widget options.
		/// </summary>
		public bool Eval { get; set; }
		
		// TODO: According to Scott, jQuery UI 2.0 will not use templates in the options. Remove this functionality when that arrives.
		/// <summary>
		/// Indicates that this option needs to be encoded on the client before the form request is sent, and decoded on the server.
		/// </summary>
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