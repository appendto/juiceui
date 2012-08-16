using System.Linq;
using System.Web.UI;
using System.ComponentModel;

using Juice.Framework;

namespace Juice {

	[ParseChildren(true)]
	[PersistChildren(false)]
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
		[DefaultValue((string) null)]
		public ITemplate TabContent { get; set; }

		protected override void CreateChildControls() {
			if(TabContent != null) {
				_templateContainer = new TabPageTemplateContainer();
				TabContent.InstantiateIn(_templateContainer);
				Controls.Add(_templateContainer);
			}
		}

		protected override void Render(HtmlTextWriter writer) {

			writer.WriteBeginTag("div");
			writer.WriteAttribute("id", ClientID);
			writer.Write(HtmlTextWriter.TagRightChar);

			base.Render(writer);

			writer.WriteEndTag("div");			
		}

		/// <summary>
		/// Searches the current naming container for a server control with the specified id parameter.
		/// </summary>
		/// <param name="id">The identifier for the control to be found.</param>
		/// <returns>The specified control, or null if the specified control does not exist.</returns>
		public Control FindControl(string id) {
			return this.TemplateContainer.Controls.All().Where(c => c.ID == id).FirstOrDefault();
		}
	}
}
