using System.ComponentModel;

namespace Juice.Framework {
	
	public class WidgetOption {
	
		public WidgetOption(PropertyDescriptor propertyDescriptor) {
			PropertyDescriptor = propertyDescriptor;
		}

		public string Name { get; set; }
		public object DefaultValue { get; set; }
		public bool RequiresEval { get; set; }
		public PropertyDescriptor PropertyDescriptor { get; set; }
	}
}