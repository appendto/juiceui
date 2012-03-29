using System.Web.UI;
using System.Collections.Generic;

namespace Juice.Framework {

	public interface IWidget {

		Page Page { get; }
		IDictionary<string, object> WidgetOptions { get; set; }

		string ClientID { get; }
		string UniqueID { get; }
		string WidgetName { get; }
		string TargetClientID { get; }

		bool AutoPostBack { get; set; }
		bool Disabled { get; set; }
		bool Visible { get; }
		
		void SaveWidgetOptions();

	}
}