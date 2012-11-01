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
		/// <param name="highlight">Adds an active state fill on track to handle</param>,
		/// <param name="trackTheme">Added to the form element</param>,
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>SliderWidget</returns>
		public SliderWidget BeginSlider(String elementId = "", Boolean highlight = false, String trackTheme = null, Boolean mini = false, String theme = null) {
			var widget = new SliderWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(highlight, trackTheme, mini, theme);

			return widget;
		}

		public HelperResult EndSlider() {
			return new HelperResult(writer => {
				(new SliderWidget(_helper)).RenderEnd(writer);
			});
		}

	}

	public class SliderWidget : JuiceMobileWidget<SliderWidget>, IDisposable {

		public SliderWidget(HtmlHelper helper) : base(helper, null) {
			_optionsMap = new Dictionary<String, String> {
				{ "highlight", "highlight" },
				{ "trackTheme", "track-theme" },
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public SliderWidget Options(Boolean highlight = false, String trackTheme = null, Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => highlight),
				JuiceHelpers.GetMemberInfo(() => trackTheme),
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Input;
			}
		}

		public override void RenderAttributes() {
			base.RenderAttributes();

			_writer.WriteAttribute("type", "range");
		}

	}
}
