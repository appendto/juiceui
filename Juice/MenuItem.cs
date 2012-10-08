using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Juice.Framework;

namespace Juice {

	[ParseChildren(typeof(MenuItem), DefaultProperty = "Items", ChildrenAsProperties = true)]
	public class MenuItem : WebControl {

		private JuiceTemplateContainer _container = null;
		private HtmlContainerControl _subMenu = null;

		public MenuItem() : base("li") {
			Items = new List<MenuItem>();
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(HtmlContainerControl))]
		public List<MenuItem> Items { get; private set; }

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DefaultValue((string)null)]
		[Browsable(false)]
		[TemplateContainer(typeof(JuiceTemplateContainer))]
		public virtual ITemplate Content { get; set; }

		protected override void CreateChildControls() {
			if(Content != null) {
				_container = new JuiceTemplateContainer();
				Content.InstantiateIn(_container);
				Controls.Add(_container);
			}

			if(Items.Count > 0) {
				_subMenu = new HtmlGenericControl("ul");

				foreach(var item in Items) {
					_subMenu.Controls.Add(item);
				}

				this.Controls.Add(_subMenu);
			}
		}

		/// <summary>
		/// Searches the current MenuItem for a sub MenuItem with the specified id parameter.
		/// </summary>
		/// <param name="id">The identifier for the MenuItem to be found.</param>
		/// <returns>The specified MenuItem, or null if the specified MenuItem does not exist.</returns>
		public Control FindItem(string id) {
			return this.Items.All().Where(c => c.ID == id).FirstOrDefault();
		}

	}
}
