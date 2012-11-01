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
		/// <param name="corners">Sets whether to draw the popup with rounded corners.</param>,
		/// <param name="dismissable">Allow popup to be closed.</param>,
		/// <param name="overlayTheme">Sets the color scheme (swatch) for the popup background, which covers the entire window.</param>,
		/// <param name="shadow">Sets whether to draw a shadow around the popup.</param>,
		/// <param name="tolerance">Sets the minimum distance from the edge of the window for the corresponding edge of the popup. By default, the values above will be used for the distance from the top, right, bottom, and left edge of the window, respectively.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>PopupWidget</returns>
		public PopupWidget BeginPopup(String elementId = "", Boolean corners = true, Boolean dismissable = true, String overlayTheme = null, Boolean shadow = true, MobileTolerance tolerance = null, String theme = null) {
			var widget = new PopupWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(corners, dismissable, overlayTheme, shadow, tolerance, theme);

			return widget;
		}

		public HelperResult EndPopup() {
			return new HelperResult(writer => {
				(new PopupWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class PopupWidget : JuiceMobileWidget<PopupWidget>, IDisposable {

		public PopupWidget(HtmlHelper helper) : base(helper, "popup") {
			_optionsMap = new Dictionary<String, String> {
				{ "corners", "corners" },
				{ "dismissable", "dismissable" },
				{ "overlayTheme", "overlay-theme" },
				{ "shadow", "shadow" },
				{ "tolerance", "tolerance" },
				{ "theme", "theme" }
			};
		}

		public PopupWidget Options(Boolean corners = true, Boolean dismissable = true, String overlayTheme = null, Boolean shadow = true, MobileTolerance tolerance = null, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => corners),
				JuiceHelpers.GetMemberInfo(() => dismissable),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => shadow),
				JuiceHelpers.GetMemberInfo(() => tolerance),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
