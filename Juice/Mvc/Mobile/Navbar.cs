using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using Juice.Mobile;

namespace Juice.Mvc.Mobile {

	public partial class MobileHelpers {

		/// <summary>
		/// {summary}
		/// </summary>
		/// <param name="icon">Icon navbar.</param>,
		/// <param name="iconpos">Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>NavbarWidget</returns>
		public NavbarWidget BeginNavbar(String elementId = "", MobileIcon? icon = null, MobileIconPosition? iconpos = null, String theme = null) {
			var widget = new NavbarWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(icon, iconpos, theme);

			return widget;
		}

		public HelperResult EndNavbar() {
			return new HelperResult(writer => {
				(new NavbarWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class NavbarWidget : JuiceMobileWidget<NavbarWidget>, IDisposable {

		private List<HelperResult> _items = new List<HelperResult>();

		public NavbarWidget(HtmlHelper helper) : base(helper, "navbar") {
			
			_optionsMap = new Dictionary<String, String> {
				{ "icon", "icon" },
				{ "iconpos", "iconpos" },
				{ "theme", "theme" }
			};
		}

		public NavbarWidget Options(MobileIcon? icon = null, MobileIconPosition? iconpos = null, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => icon),
				JuiceHelpers.GetMemberInfo(() => iconpos),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		public NavbarWidget AddItem(Func<NavbarWidget, HelperResult> content) {

			HelperResult res = content(this);

			_items.Add(res);

			return this;
		}

		public override void RenderStart() {
			base.RenderStart();

			_writer.WriteFullBeginTag("ul");

			foreach(var item in _items) {

				_writer.WriteBeginTag("li");
				_writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar);

				_writer.Write(item.ToHtmlString());

				_writer.WriteEndTag("li");
			}

			_writer.WriteEndTag("ul");
			
		}

	}
}
