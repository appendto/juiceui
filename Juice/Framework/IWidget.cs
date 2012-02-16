using System.Web.UI;
using System.Collections.Generic;

namespace Juice.Framework {
	public interface IWidget {
		string WidgetName { get; }
		Page Page { get; }
		string ClientID { get; }
		string UniqueID { get; }
		bool Visible { get; }
		void SaveWidgetOptions();
		IDictionary<string, object> WidgetOptions{get;set;}
	}
}