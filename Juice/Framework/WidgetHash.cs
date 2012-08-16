using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Juice.Framework {

	internal class WidgetHash {

		public WidgetHash(IWidget widget, IList<String> encodedOptions, IList<WidgetEvent> events, Control targetControl) {
			WidgetName = widget.WidgetName;
			WidgetUniqueId = widget.UniqueID;
			TargetControl = targetControl;
			Options = widget.WidgetOptions;
			EncodedOptions = encodedOptions;
			Events = events;
		}
		
		public Control TargetControl { get; private set; }

		public String WidgetUniqueId { get; private set; }
		
		public String WidgetName { get; private set; }

		public IDictionary<String, Object> Options { get; private set; }

		public IList<WidgetEvent> Events { get; private set; }

		public IList<String> EncodedOptions { get; private set; }
	}
}