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
		/// <param name="contentTheme">Sets the color scheme (swatch) for the collapsible content block. It accepts a single letter from a-z that maps to one of the swatches included in your theme.</param>,
		/// <param name="mini">Sets the size of the element to a more compact, mini version.</param>,
		/// <param name="inset">By setting this option to false the collapsibles will get a full width appearance without corners.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>CollapsibleSetWidget</returns>
		public CollapsibleSetWidget BeginCollapsibleSet(String elementId = "", String contentTheme = null, Boolean mini = false, Boolean inset = true, String theme = null) {
			var widget = new CollapsibleSetWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(contentTheme, mini, inset, theme);

			return widget;
		}

		public HelperResult EndCollapsibleSet() {
			return new HelperResult(writer => {
				(new CollapsibleSetWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class CollapsibleSetWidget : JuiceMobileWidget<CollapsibleSetWidget>, IDisposable {

		public CollapsibleSetWidget(HtmlHelper helper) : base(helper, "collapsible-set") {
			_optionsMap = new Dictionary<String, String> {
				{ "contentTheme", "content-theme" },
				{ "mini", "mini" },
				{ "inset", "inset" },
				{ "theme", "theme" }
			};
		}

		public CollapsibleSetWidget Options(String contentTheme = null, Boolean mini = false, Boolean inset = true, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => contentTheme),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => inset),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
