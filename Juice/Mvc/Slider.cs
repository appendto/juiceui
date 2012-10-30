using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Drag a handle to select a numeric value.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Slider if set to true.</param>
		/// <param name="animate">Whether to slide the handle smoothly when the user clicks on the slider track. Also accepts any valid animation duration.</param>
		/// <param name="max">The maximum value of the slider.</param>
		/// <param name="min">The minimum value of the slider.</param>
		/// <param name="orientation">Determines whether the slider handles move horizontally (min on left, max on right) or vertically (min on bottom, max on top). Possible values: "horizontal", "vertical".</param>
		/// <param name="range">Whether the slider represents a range.</param>
		/// <param name="step">Determines the size or amount of each interval or step the slider takes between the min and max.</param>
		/// <param name="value">Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.</param>
		/// <param name="values">This option can be used to specify multiple handles. If the range option is set to true, the length of values should be 2.</param>
		/// <returns></returns>
		public SliderWidget Slider(String elementId = "", String target = "", Boolean disabled = false, dynamic animate = null, int max = 100, int min = 0, String orientation = "horizontal", dynamic range = null, int step = 1, int value = 0, int[] values = null) {
			var widget = new SliderWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, animate, max, min, orientation, range, step, animate, values);

			return widget;
		}

	}

	public class SliderWidget : JuiceWidget<SliderWidget>, IDisposable {

		public SliderWidget(HtmlHelper helper) : base(helper, "slider") { }

		public SliderWidget Options(Boolean disabled = false, dynamic animate = null, int max = 100, int min = 0, String orientation = "horizontal", dynamic range = null, int step = 1, int value = 0, int[] values = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => animate),
				JuiceHelpers.GetMemberInfo(() => max),
				JuiceHelpers.GetMemberInfo(() => min),
				JuiceHelpers.GetMemberInfo(() => orientation),
				JuiceHelpers.GetMemberInfo(() => range),
				JuiceHelpers.GetMemberInfo(() => step),
				JuiceHelpers.GetMemberInfo(() => animate),
				JuiceHelpers.GetMemberInfo(() => values)
			);

			return this;
		}

	}
}
