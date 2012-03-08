using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Framework {

	internal class WidgetEvent {

		public WidgetEvent(string name) {
			Name = name;
		}

		public String Name { get; private set; }
		public Boolean CausesPostBack { get; set; }
		public Boolean DataChangedEvent { get; set; }

		//public Lazy<string> PostBackHandler { get; set; }
	}
}