using System;
using System.Collections.Generic;

namespace Juice.Framework {

	internal class WidgetHash {

		public WidgetHash(String extenderUniqueId, IDictionary<String, Object> options, IList<WidgetEvent> events) {
			UniqueId = extenderUniqueId;
			Options = options;
			Events = events;
		}

		public string UniqueId { get; private set; }

		public IDictionary<String, Object> Options { get; private set; }

		public IList<WidgetEvent> Events { get; private set; }
	}
}