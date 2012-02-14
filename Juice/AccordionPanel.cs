using System.Web.UI;

namespace Juice {

	[ParseChildren(true)]
	public class AccordionPanel : Control, INamingContainer {

		private Control _templateContainer;

		public string Title { get; set; }

		public Control TemplateContainer {
			get {
				this.EnsureChildControls();

				return _templateContainer;
			}
		}

		[TemplateContainer(typeof(AccordionPanelTemplateContainer))]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ITemplate PanelContent { get; set; }

		protected override void CreateChildControls() {
			if(PanelContent != null) {
				_templateContainer = new AccordionPanelTemplateContainer();
				PanelContent.InstantiateIn(_templateContainer);
				Controls.Add(_templateContainer);
			}
		}
	}

}
