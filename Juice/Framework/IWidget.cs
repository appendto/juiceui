using System.Web.UI;

namespace Juice.Framework {
	
	internal interface IWidget {
		string WidgetName { get; }
		Page Page { get; }
		string ClientID { get; }
		string UniqueID { get; }
		bool Visible { get; }
	}
}