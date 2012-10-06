using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {
	/// <summary>
	/// Extend a TextBox or input text element with the jQuery UI Spinner http://api.jqueryui.com/spinner/
	/// </summary>
	[TargetControlType(typeof(TextBox)), TargetControlType(typeof(HtmlInputText))]
	[WidgetEvent("create")]
	[WidgetEvent("start")]
	[WidgetEvent("spin")]
	[WidgetEvent("stop")]
	public class Spinner : JuiceExtender, IAutoPostBackWidget {

		public Spinner() : base("spinner") {

		}

		#region Widget Options

		/// <summary>
		/// Sets the culture to use for parsing and formatting the value.
		/// Reference: http://api.jqueryui.com/spinner/#option-icons
		/// </summary>
		[WidgetOption("culture", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Sets the culture to use for parsing and formatting the value.")]
		public string Culture { get; set; }

		/// <summary>
		/// Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.
		/// Reference: http://api.jqueryui.com/spinner/#option-icons
		/// </summary>
		[WidgetOption("icons", "{ down: \"ui-icon-triangle-1-s\", up: \"ui-icon-triangle-1-n\" }", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{ down: \"ui-icon-triangle-1-s\", up: \"ui-icon-triangle-1-n\" }")]
		[Description("Icons to use for buttons, matching an icon defined by the jQuery UI CSS Framework.")]
		public string Icons { get; set; }

		/// <summary>
		/// Controls the number of steps taken when holding down a spin button.
		/// Reference: http://api.jqueryui.com/spinner/#option-incremental
		/// </summary>
		[WidgetOption("incremental", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Controls the number of steps taken when holding down a spin button.")]
		public bool Incremental { get; set; }

		/// <summary>
		/// The maximum allowed value. The element's max attribute is used if it exists and the option is not explicitly set. If null, there is no maximum enforced.
		/// Reference: http://api.jqueryui.com/spinner/#option-max
		/// </summary>
		[WidgetOption("max", null)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The maximum allowed value. The element's max attribute is used if it exists and the option is not explicitly set. If null, there is no maximum enforced.")]
		public dynamic Max { get; set; }

		/// <summary>
		/// The minimum allowed value. The element's min attribute is used if it exists and the option is not explicitly set. If null, there is no minimum enforced.
		/// Reference: http://api.jqueryui.com/spinner/#option-min
		/// </summary>
		[WidgetOption("min", null)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The minimum allowed value. The element's min attribute is used if it exists and the option is not explicitly set. If null, there is no minimum enforced.")]
		public dynamic Min { get; set; }

		/// <summary>
		/// Format of numbers passed to Globalize, if available.
		/// Reference: http://api.jqueryui.com/spinner/#option-numberFormat
		/// </summary>
		[WidgetOption("numberFormat", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Format of numbers passed to Globalize, if available.")]
		public string NumberFormat { get; set; }

		/// <summary>
		/// The number of steps to take when paging via the pageUp/pageDown methods.
		/// Reference: http://api.jqueryui.com/spinner/#option-numberFormat
		/// </summary>
		[WidgetOption("page", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The number of steps to take when paging via the pageUp/pageDown methods.")]
		// Can't name this "Page" without messing with the Control.Page property. Would be messy if anyone tried inheriting.
		public int PageSteps { get; set; }

		/// <summary>
		/// The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods.
		/// Reference: http://api.jqueryui.com/spinner/#option-min
		/// </summary>
		[WidgetOption("step", null)]
		[TypeConverter(typeof(StringToObjectConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("The size of the step to take when spinning via buttons or via the stepUp()/stepDown() methods.")]
		public dynamic Step { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered when the value of the spinner changes.
		/// Reference: http://api.jqueryui.com/spinner/#event-change
		/// </summary>
		[WidgetEvent("change", AutoPostBack = true)]
		[Category("Action")]
		[Description("This event is triggered when the value of the spinner changes.")]
		public event EventHandler ValueChanged;

		#endregion
	}
}