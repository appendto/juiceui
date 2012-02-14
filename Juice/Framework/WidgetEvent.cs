using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Framework {

	internal class WidgetEvent {

		public string Name { get; private set; }

		public Lazy<string> PostBackHandler { get; set; }

		public WidgetEvent(string name) {
			Name = name;
		}
	}
}