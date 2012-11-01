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
		/// <param name="max">The maximum value of the slider.</param>
		/// <param name="min">The minimum value of the slider.</param>
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <param name="value">Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.</param>
		/// <returns>SliderWidget</returns>
		public SliderWidget Slider(String elementId = "", Boolean highlight = false, String trackTheme = null, int max = 100, int min = 0, Boolean mini = false, String theme = null, int value = 0) {
			var widget = new SliderWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(highlight, trackTheme, max, min, mini, theme, value);

			return widget;
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

		public SliderWidget Options(Boolean highlight = false, String trackTheme = null, int max = 100, int min = 0, Boolean mini = false, String theme = null, int value = 0) {

			this.AddAttribute("min", min.ToString());
			this.AddAttribute("max", max.ToString());
			this.AddAttribute("value", value.ToString());
			
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

		public override void Render() {
			base.Render();

			if(_content != null) {
				base.RenderEnd();
			}
		}
	}
}
