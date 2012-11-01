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
		/// <param name="addBackBtn">Add a back button to the page.</param>,
		/// <param name="backBtnText">Text of the back button.</param>,
		/// <param name="backBtnTheme">Sets the color scheme (swatch) for the back button.</param>,
		/// <param name="closeBtnText">text for the close button, dialog only.</param>,
		/// <param name="domCache">Apply dom-cache.</param>,
		/// <param name="fullscreen">Used in conjunction with fixed toolbars.</param>,
		/// <param name="overlayTheme">overlay theme when the page is opened in a dialog.</param>,
		/// <param name="title">Title used when page is shown.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>PageWidget</returns>
		public PageWidget BeginPage(String elementId = "", Boolean addBackBtn = false, String backBtnText = "Back", String backBtnTheme = null, String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "Juice UI Mobile Dialog", String theme = null) {
			var widget = new PageWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(addBackBtn, backBtnText, backBtnTheme, closeBtnText, domCache, fullscreen, overlayTheme, title, theme);

			return widget;
		}

		public HelperResult EndPage() {
			return new HelperResult(writer => {
				(new PageWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class PageWidget : JuiceMobileWidget<PageWidget>, IDisposable {

		public PageWidget(HtmlHelper helper) : base(helper, "page") {
			_optionsMap = new Dictionary<String, String> {
				{ "addBackBtn", "add-back-btn" },
				{ "backBtnText", "back-btn-text" },
				{ "backBtnTheme", "back-btn-theme" },
				{ "closeBtnText", "close-btn-text" },
				{ "domCache", "dom-cache" },
				{ "fullscreen", "fullscreen" },
				{ "overlayTheme", "overlay-theme" },
				{ "title", "title" },
				{ "theme", "theme" }
			};
		}

		public PageWidget Options(Boolean addBackBtn = false, String backBtnText = "Back", String backBtnTheme = null, String closeBtnText = "Close", Boolean domCache = false, Boolean fullscreen = false, String overlayTheme = null, String title = "Juice UI Mobile Dialog", String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => addBackBtn),
				JuiceHelpers.GetMemberInfo(() => backBtnText),
				JuiceHelpers.GetMemberInfo(() => backBtnTheme),
				JuiceHelpers.GetMemberInfo(() => closeBtnText),
				JuiceHelpers.GetMemberInfo(() => domCache),
				JuiceHelpers.GetMemberInfo(() => fullscreen),
				JuiceHelpers.GetMemberInfo(() => overlayTheme),
				JuiceHelpers.GetMemberInfo(() => title),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
