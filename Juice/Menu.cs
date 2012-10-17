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
	[WidgetEvent("blur")]
	[WidgetEvent("create")]
	[WidgetEvent("focus")]
	[WidgetEvent("select")]
	public class Menu : JuiceScriptControl, IAutoPostBackWidget {

		public Menu() : base("menu") {
			Items = new List<MenuItem>();
		}

		[PersistenceMode(PersistenceMode.InnerProperty)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[TemplateContainer(typeof(MenuItem))]
		public List<MenuItem> Items { get; private set; }

		#region Widget Options

		/// <summary>
		/// Icons to use for submenus, matching an icon defined by the jQuery UI CSS Framework.
		/// Reference: http://api.jqueryui.com/menu/#option-icons
		/// </summary>
		[WidgetOption("icons", "{ submenu: \"ui-icon-carat-1-e\" }", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{ submenu: \"ui-icon-carat-1-e\" }")]
		[Description("Icons to use for submenus, matching an icon defined by the jQuery UI CSS Framework.")]
		public string Icons { get; set; }

		/// <summary>
		/// Selector for the elements that serve as the menu container, including sub-menus.
		/// Reference: http://api.jqueryui.com/menu/#option-menu
		/// </summary>
		[WidgetOption("menu", "ul")]
		[Category("Behavior")]
		[DefaultValue("ul")]
		[Description("Selector for the elements that serve as the menu container, including sub-menus.")]
		public string MenuSelector { get; set; }

		/// <summary>
		/// Identifies the position of submenus in relation to the associated parent menu item. The of option defaults to the parent menu item, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.
		/// Reference: http://api.jqueryui.com/menu/#option-position
		/// </summary>
		[WidgetOption("position", "{ my: \"top left\", at: \"top right\" }", Eval = true)]
		[TypeConverter(typeof(JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("{ my: \"top left\", at: \"top right\" }")]
		[Description("Identifies the position of submenus in relation to the associated parent menu item. The of option defaults to the parent menu item, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.")]
		public string Position { get; set; }

		/// <summary>
		/// Customize the ARIA roles used for the menu and menu items. The default uses "menuitem" for items. Setting the role option to "listbox" will use "option" for items. If set to null, no roles will be set, which is useful if the menu is being controlled by another element that is maintaining focus.
		/// Reference: http://api.jqueryui.com/menu/#option-menu
		/// </summary>
		[WidgetOption("role", "menu")]
		[Category("Behavior")]
		[DefaultValue("menu")]
		[Description("Customize the ARIA roles used for the menu and menu items. The default uses \"menuitem\" for items. Setting the role option to \"listbox\" will use \"option\" for items. If set to null, no roles will be set, which is useful if the menu is being controlled by another element that is maintaining focus.")]
		public string Role { get; set; }

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
