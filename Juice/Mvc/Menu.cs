using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Display status of a determinate process.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Menu if set to true.</param>
		/// <param name="value">The value of the Menu.</param>
		/// <returns>MenuWidget</returns>
		public MenuWidget Menu(String elementId = "", String target = "", Boolean disabled = false, MenuIcons icons = null, String menus = "ul", PositionOptions position = null, String role = "menu") {
			var widget = new MenuWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, icons, menus, position, role);

			return widget;
		}

	}

	public class MenuWidget : JuiceWidget<MenuWidget>, IDisposable {

		public MenuWidget(HtmlHelper helper) : base(helper, "menu") { }

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Ul;
			}
		}

		public MenuWidget Options(Boolean disabled = false, MenuIcons icons = null, String menus = "ul", PositionOptions position = null, String role = "menu") {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => icons),
				JuiceHelpers.GetMemberInfo(() => menus),
				JuiceHelpers.GetMemberInfo(() => position),
				JuiceHelpers.GetMemberInfo(() => role)
			);

			return this;
		}

	}
}
