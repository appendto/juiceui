using System.Web.UI;
using System.Collections.Generic;

namespace Juice.Framework {

	public interface IWidget {
		
		Page Page { get; }
		IDictionary<string, object> WidgetOptions { get; set; }

		string ClientID { get; }
		string UniqueID { get; }
		string WidgetName { get; }

		bool Visible { get; }
		
		void SaveWidgetOptions();

	}
}