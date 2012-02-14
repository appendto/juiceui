using System.Web.UI;

namespace Juice {

	[ParseChildren(true)]
	public class TabPage : Control, INamingContainer {
	
		private Control _templateContainer;

		public string Title { get; set; }

		public Control TemplateContainer {
			get {
				this.EnsureChildControls();

				return _templateContainer;
			}
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[TemplateContainer(typeof(TabPageTemplateContainer))]
		public ITemplate TabContent { get; set; }

		protected override void CreateChildControls() {
			if(TabContent != null) {
				_templateContainer = new TabPageTemplateContainer(this);
				TabContent.InstantiateIn(_templateContainer);
				Controls.Add(_templateContainer);
			}
		}
	}
}
