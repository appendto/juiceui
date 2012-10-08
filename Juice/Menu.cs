using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {

	internal static class MenuExtensions {

		/// <summary>
		/// Allows Linq operations on the controls collection.
		/// </summary>
		internal static IEnumerable<MenuItem> All(this List<MenuItem> items) {
			foreach(MenuItem item in items) {
				foreach(MenuItem grandChild in item.Items.All())
					yield return grandChild;

				yield return item;
			}
		}

	}

	[ParseChildren(typeof(MenuItem), DefaultProperty = "Items", ChildrenAsProperties = true)]
	public class Menu : JuiceScriptControl, IAutoPostBackWidget {

		public Menu() : base("menu") {
			Items = new List<MenuItem>();
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(MenuItem))]
		public List<MenuItem> Items { get; private set; }

		#region Widget Options



		#endregion

		#region Widget Events

		

		#endregion

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Ul;
			}
		}

		public override ControlCollection Controls {
			get {
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		protected override void OnPreRender(EventArgs e) {

			if(this.Items != null) {
				foreach(var item in this.Items) {
					this.Controls.Add(item);
				}
			}

			base.OnPreRender(e);
		}

		protected override void Render(HtmlTextWriter writer) {

			this.RenderBeginTag(writer);

			this.RenderChildren(writer);

			this.RenderEndTag(writer);
		}

		/// <summary>
		/// Searches the current menu for a MenuItem with the specified id parameter.
		/// </summary>
		/// <param name="id">The identifier for the MenuItem to be found.</param>
		/// <returns>The specified MenuItem, or null if the specified MenuItem does not exist.</returns>
		public Control FindItem(string id) {
			return this.Items.All().Where(c => c.ID == id).FirstOrDefault();
		}
	}
}
