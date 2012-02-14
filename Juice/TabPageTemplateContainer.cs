using System.Web.UI;

namespace Juice {

	public class TabPageTemplateContainer : Control, INamingContainer {

		private TabPage _parentTab;

		public TabPageTemplateContainer(TabPage ParentTab) {
			this._parentTab = ParentTab;
		}
	}
}