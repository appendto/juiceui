using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using Juice.Mobile;

namespace Juice.Mvc.Mobile {

	public static class ButtonExtensions {

		/// <summary>
		/// Extends an AnchorWidget with DialogWidget options.
		/// </summary>
		/// <param name="closeBtnText">Customizes the text of the close button which is helpful for translating this into different languages.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="fullscreen">Show dialog in fullscreen.</param>,
		/// <param name="overlayTheme">Overlay theme when the page is opened in a dialog.</param>,
		/// <param name="title">Title used when page is shown.</param>,
		/// <param name="transition">By default, the dialog will open with a 'pop' transition.</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>DialogWidget</returns>
		public static AnchorWidget DialogOptions(this AnchorWidget widget, String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "", MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			widget.SetOptions(
				JuiceHelpers.GetMemberInfo(() => closeBtnText),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => fullscreen),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => title),
				JuiceHelpers.GetMemberInfo(() => transition),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);
			return widget;
		}

		/// <summary>
		/// Extends a ButtonWidget with DialogWidget options.
		/// </summary>
		/// <param name="closeBtnText">Customizes the text of the close button which is helpful for translating this into different languages.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="fullscreen">Show dialog in fullscreen.</param>,
		/// <param name="overlayTheme">Overlay theme when the page is opened in a dialog.</param>,
		/// <param name="title">Title used when page is shown.</param>,
		/// <param name="transition">By default, the dialog will open with a 'pop' transition.</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>DialogWidget</returns>
		public static ButtonWidget DialogOptions(this ButtonWidget widget, String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "", MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			widget.SetOptions(
				JuiceHelpers.GetMemberInfo(() => closeBtnText),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => fullscreen),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => title),
				JuiceHelpers.GetMemberInfo(() => transition),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);
			return widget;
		}
	}

	public partial class MobileHelpers {

		/// <summary>
		/// {summary}
		/// </summary>
		/// <param name="closeBtnText">Customizes the text of the close button which is helpful for translating this into different languages.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="fullscreen">Show dialog in fullscreen.</param>,
		/// <param name="overlayTheme">Overlay theme when the page is opened in a dialog.</param>,
		/// <param name="title">Title used when page is shown.</param>,
		/// <param name="transition">By default, the dialog will open with a 'pop' transition.</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>DialogWidget</returns>
		public DialogWidget BeginDialog(String elementId = "", String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "", MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			var widget = new DialogWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(closeBtnText, domCache, fullscreen, overlayTheme, title, transition, mini, theme);

			return widget;
		}

		public HelperResult EndDialog() {
			return new HelperResult(writer => {
				(new DialogWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class DialogWidget : JuiceMobileWidget<DialogWidget>, IDisposable {

		public DialogWidget(HtmlHelper helper) : base(helper, null) {
			_optionsMap = new Dictionary<String, String> {
				{ "closeBtnText", "close-btn-text" },
				{ "domCache", "dom-cache" },
				{ "fullscreen", "fullscreen" },
				{ "overlayTheme", "overlay-theme" },
				{ "title", "title" },
				{ "transition", "transition" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public DialogWidget Options(String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "", MobileTransition? transition = null, Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => closeBtnText),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => fullscreen),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => title),
				JuiceHelpers.GetMemberInfo(() => transition),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
