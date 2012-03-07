using System;

namespace Juice.Framework {

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Event, AllowMultiple = true)]
	public class WidgetEventAttribute : Attribute {

		public WidgetEventAttribute(String name) {
			Name = name;
		}

		public string Name { get; set; }

		public Boolean AutoPostBack { get; set; }
		public Boolean DataChangedHandler { get; set; }

		public override object TypeId { get { return Name; } }
	}
}