using System.Web.UI;

namespace Juice {

	[ParseChildren(true)]
	[PersistChildren(false)]
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

		protected override void Render(HtmlTextWriter writer) {

			writer.WriteFullBeginTag("h3");

			writer.WriteBeginTag("a");
			writer.AddAttribute("href", "#");
			writer.Write(HtmlTextWriter.TagRightChar);
			writer.Write(Title);
			writer.WriteEndTag("a");

			writer.WriteEndTag("h3");

			// Panel content wrapper div
			writer.WriteFullBeginTag("div");

			base.Render(writer);

			writer.WriteEndTag("div");
		}
	}

}
