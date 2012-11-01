using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Enhance a text input for entering numeric values, with up/down buttons and arrow key handling.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Spinner if set to true.</param>
		/// <param name="culture">Sets the culture to use for parsing and formatting the value. If null, the currently set culture in Globalize is used, see Globalize docs for available cultures. Only relevant if the numberFormat option is set. Requires Globalize to be included.</param>
		/// <param name="icons">Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.</param>
		/// <param name="incremental">Controls the number of steps taken when holding down a spin button.</param>
		/// <param name="max">The maximum allowed value. The element's max attribute is used if it exists and the option is not explicitly set. If null, there is no maximum enforced.</param>
		/// <param name="min">The minimum allowed value. The element's min attribute is used if it exists and the option is not explicitly set. If null, there is no minimum enforced.</param>
		/// <param name="numberFormat">Format of numbers passed to Globalize, if available. Most common are "n" for a decimal number and "C" for a currency value. Also see the culture option.</param>
		/// <param name="page">The number of steps to take when paging via the pageUp/pageDown methods.</param>
		/// <param name="step">The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods. The element's step attribute is used if it exists and the option is not explicitly set.</param>
		/// <returns>SpinnerWidget</returns>
		public SpinnerWidget Spinner(String elementId = "", String target = "", Boolean disabled = false, String culture = null, SpinnerIcons icons = null, Boolean incremental = true, dynamic max = null, dynamic min = null, String numberFormat = null, int page = 10, dynamic step = null) {
			var widget = new SpinnerWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, culture, icons, incremental, max, min, numberFormat, page, step);

			return widget;
		}

	}

	public class SpinnerWidget : JuiceWidget<SpinnerWidget>, IDisposable {

		public SpinnerWidget(HtmlHelper helper) : base(helper, "spinner") { }

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Input;
			}
		}

		public SpinnerWidget Options(Boolean disabled = false, String culture = null, SpinnerIcons icons = null, Boolean incremental = true, dynamic max = null, dynamic min = null, String numberFormat = null, int page = 10, dynamic step = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => culture), 
				JuiceHelpers.GetMemberInfo(() => icons), 
				JuiceHelpers.GetMemberInfo(() => incremental), 
				JuiceHelpers.GetMemberInfo(() => max), 
				JuiceHelpers.GetMemberInfo(() => min), 
				JuiceHelpers.GetMemberInfo(() => numberFormat), 
				JuiceHelpers.GetMemberInfo(() => page), 
				JuiceHelpers.GetMemberInfo(() => step)
			);

			return this;
		}

	}
}
