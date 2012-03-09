using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Juice.Framework {

	internal class PostBackHash {

		public PostBackHash() { }

		public String ControlID { get; set; }
		public String WidgetName { get; set; }
		public Dictionary<String, object> Options { get; set; }
	}
}