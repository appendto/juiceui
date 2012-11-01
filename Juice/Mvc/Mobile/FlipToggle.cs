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
		/// <param name="mini">Sets the size of the element to a more compact, mini version.</param>,
		/// <param name="trackTheme">Sets the color scheme (swatch) for the slider's track, specifically. It accepts a single letter from a-z that maps to one of the swatches included in your theme.</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>FlipToggleWidget</returns>
		public FlipToggleWidget BeginFlipToggle(String elementId = "", Boolean mini = false, String trackTheme = null, String theme = null) {
			var widget = new FlipToggleWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(mini, trackTheme, theme);

			return widget;
		}

		public HelperResult EndFlipToggle() {
			return new HelperResult(writer => {
				(new FlipToggleWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class FlipToggleWidget : JuiceMobileWidget<FlipToggleWidget>, IDisposable {

		public FlipToggleWidget(HtmlHelper helper) : base(helper, "slider") {
			_optionsMap = new Dictionary<String, String> {
				{ "mini", "mini" },
				{ "trackTheme", "track-theme" },
				{ "theme", "theme" }
			};
		}

		public FlipToggleWidget Options(Boolean mini = false, String trackTheme = null, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => trackTheme),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

	}
}
