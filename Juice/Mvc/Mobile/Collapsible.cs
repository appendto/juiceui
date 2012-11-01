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
		/// <param name="collapsed">When false, the container is initially expanded with a minus icon in the header.</param>,
		/// <param name="contentTheme">Sets the color scheme (swatch) for the collapsible content block. It accepts a single letter from a-z that maps to one of the swatches included in your theme.</param>,
		/// <param name="mini">Sets the size of the element to a more compact, mini version.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>CollapsibleWidget</returns>
		public CollapsibleWidget BeginCollapsible(String elementId = "", Boolean collapsed = true, MobileIcon? collapsedIcon = null, String contentTheme = null, MobileIcon? expandedIcon = null, MobileIconPosition? iconpos = null, Boolean inset = true, Boolean mini = false, String theme = null) {
			var widget = new CollapsibleWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(collapsed, collapsedIcon, contentTheme, expandedIcon, iconpos, inset, mini, theme);

			return widget;
		}

		public HelperResult EndCollapsible() {
			return new HelperResult(writer => {
				(new CollapsibleWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class CollapsibleWidget : JuiceMobileWidget<CollapsibleWidget>, IDisposable {

		public CollapsibleWidget(HtmlHelper helper) : base(helper, "collapsible") {
			_optionsMap = new Dictionary<String, String> {
				{ "collapsed", "collapsed" },
				{ "collapsedIcon", "collapsed-icon" },
				{ "contentTheme", "content-theme" },
				{ "expandedIcon", "expanded-icon" },
				{ "iconpos", "iconpos" },
				{ "inset", "inset" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public CollapsibleWidget Options(Boolean collapsed = true, MobileIcon? collapsedIcon = null, String contentTheme = null, MobileIcon? expandedIcon = null, MobileIconPosition? iconpos = null, Boolean inset = true, Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => collapsed),
				JuiceHelpers.GetMemberInfo(() => collapsedIcon),
				JuiceHelpers.GetMemberInfo(() => contentTheme),
				JuiceHelpers.GetMemberInfo(() => expandedIcon),
				JuiceHelpers.GetMemberInfo(() => iconpos),
				JuiceHelpers.GetMemberInfo(() => inset),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
