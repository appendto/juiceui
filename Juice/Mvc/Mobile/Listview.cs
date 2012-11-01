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
		/// <param name="countTheme">Sets the color scheme (swatch) for list item count bubbles.</param>,
		/// <param name="dividertheme">Sets the color scheme (swatch) for list dividers.</param>,
		/// <param name="filter">Adds a search filter bar to listviews.</param>,
		/// <param name="filterPlaceholder">Adds a search filter bar to listviews.</param>,
		/// <param name="filterTheme">Sets the color scheme (swatch) for the search filter bar.</param>,
		/// <param name="inset">Adds inset list styles.</param>,
		/// <param name="splitIcon">Applies an icon from the icon set to all split list buttons.</param>,
		/// <param name="splitTheme">Sets the color scheme (swatch) for split list buttons.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>ListviewWidget</returns>
		public ListviewWidget BeginListview(String elementId = "", String countTheme = "c", String dividertheme = "b", Boolean filter = false, String filterPlaceholder = null, String filterTheme = "c", Boolean inset = false, MobileIcon? splitIcon = null, String splitTheme = "b", String theme = null) {
			var widget = new ListviewWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(countTheme, dividertheme, filter, filterPlaceholder, filterTheme, inset, splitIcon, splitTheme, theme);

			return widget;
		}

		public HelperResult EndListview() {
			return new HelperResult(writer => {
				(new ListviewWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class ListviewWidget : JuiceMobileWidget<ListviewWidget>, IDisposable {

		public ListviewWidget(HtmlHelper helper) : base(helper, "listview") {
			_optionsMap = new Dictionary<String, String> {
				{ "countTheme", "count-theme" },
				{ "dividertheme", "dividertheme" },
				{ "filter", "filter" },
				{ "filterPlaceholder", "filter-placeholder" },
				{ "filterTheme", "filter-theme" },
				{ "inset", "inset" },
				{ "splitIcon", "split-icon" },
				{ "splitTheme", "split-theme" },
				{ "theme", "theme" }
			};
		}

		public ListviewWidget Options(String countTheme = "c", String dividertheme = "b", Boolean filter = false, String filterPlaceholder = null, String filterTheme = "c", Boolean inset = false, MobileIcon? splitIcon = null, String splitTheme = "b", String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => countTheme),
				JuiceHelpers.GetMemberInfo(() => dividertheme),
				JuiceHelpers.GetMemberInfo(() => filter),
				JuiceHelpers.GetMemberInfo(() => filterPlaceholder),
				JuiceHelpers.GetMemberInfo(() => filterTheme),
				JuiceHelpers.GetMemberInfo(() => inset),
				JuiceHelpers.GetMemberInfo(() => splitIcon),
				JuiceHelpers.GetMemberInfo(() => splitTheme),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
