using System;
using System.ComponentModel;

namespace Juice.Framework {

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class WidgetDocumentAttribute : Attribute {

		public WidgetDocumentAttribute(string name) {
			Name = name;
		}

		public WidgetDocumentAttribute(string name, object defaultValue) {
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
	}
}
