using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Juice.Framework {

	internal class WidgetHash {

		public WidgetHash(IWidget widget, IList<WidgetEvent> events, Control targetControl) : this(targetControl, widget.WidgetName, widget.WidgetOptions, events) { }

		public WidgetHash(Control targetControl, String widgetName, IDictionary<String, Object> options, IList<WidgetEvent> events) {
			WidgetName = widgetName;
			TargetControl = targetControl;
			Options = options;
			Events = events;
		}

		public Control TargetControl { get; private set; }

		public String WidgetName { get; private set; }

		public IDictionary<String, Object> Options { get; private set; }

		public IList<WidgetEvent> Events { get; private set; }
	}
}