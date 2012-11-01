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
		/// <param name="elementId">Sets the id attribute of the rendered element.</param>
		/// <param name="icon">Applies an icon from the icon set.</param>,
		/// <param name="iconpos">Positions the icon in the button. Possible values: left, right, top, bottom, none, notext. The notext value will display an icon-only button with no text feedback.</param>,
		/// <param name="inline">Display the control inline, horizontally.</param>,
		/// <param name="nativeMenu">Display the native OS menu.</param>,
		/// <param name="overlayTheme">Overlay theme for non-native selects</param>,
		/// <param name="placeholder">Can be set on option element of a non-native select</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>SelectWidget</returns>
		public SelectWidget Select(String elementId = "", MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean inline = false, Boolean nativeMenu = true, String overlayTheme = null, Boolean placeholder = false, Boolean mini = false, String theme = null) {
			var widget = new SelectWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(icon, iconpos, inline, nativeMenu, overlayTheme, placeholder, mini, theme);

			return widget;
		}
	}

	public class SelectWidget : JuiceMobileWidget<SelectWidget>, IDisposable {

		public SelectWidget(HtmlHelper helper) : base(helper, null) {
			_optionsMap = new Dictionary<String, String> {
				{ "icon", "icon" },
				{ "iconpos", "iconpos" },
				{ "inline", "inline" },
				{ "nativeMenu", "native-menu" },
				{ "overlayTheme", "overlay-theme" },
				{ "placeholder", "placeholder" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public SelectWidget Options(MobileIcon? icon = null, MobileIconPosition? iconpos = null, Boolean inline = false, Boolean nativeMenu = true, String overlayTheme = null, Boolean placeholder = false, Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => icon),
				JuiceHelpers.GetMemberInfo(() => iconpos),
				JuiceHelpers.GetMemberInfo(() => inline),
				JuiceHelpers.GetMemberInfo(() => nativeMenu),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => placeholder),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Select;
			}
		}

		public override void Render() {
			base.Render();
			base.RenderEnd();
		}

	}
}
