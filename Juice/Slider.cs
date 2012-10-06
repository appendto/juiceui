using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;

using Juice.Framework;
using Juice.Framework.TypeConverters;

namespace Juice {

	[WidgetEvent("create")]
	[WidgetEvent("start")]
	[WidgetEvent("slide")]
	[WidgetEvent("stop")]
	[ControlValueProperty("Value")]
	public class Slider : JuiceScriptControl, IAutoPostBackWidget {

		private static readonly object _changeEvent = new object();

		// TODO: Plumb the AccessKey value through to the rendered a tag

		public Slider() : base("slider") {

		}

		#region Widget Options

		/// <summary>
		/// Whether to slide handle smoothly when user click outside handle on the bar. Will also accept a string representing one of the three predefined speeds ("slow", "normal", or "fast") or the number of milliseconds to run the animation (e.g. 1000).
		/// Reference: http://api.jqueryui.com/slider/#option-animate
		/// </summary>
		[WidgetOption("animate", false)]
		[DefaultValue(false)]
		[Description("Whether to slide handle smoothly when user click outside handle on the bar. Will also accept a string representing one of the three predefined speeds ('slow', 'normal', or 'fast') or the number of milliseconds to run the animation (e.g. 1000).")]
		[Category("Appearance")]
		public dynamic Animate {
			get {
				return ViewState["Animate"] ?? false;
			}
			set {
				ViewState["Animate"] = value;
			}
		}

		/// <summary>
		/// The maximum value of the slider.
		/// Reference: http://api.jqueryui.com/slider/#option-max
		/// </summary>
		[WidgetOption("max", 100)]
		[DefaultValue(100)]
		[Description("The maximum value of the slider.")]
		[Category("Behavior")]
		public int Max {
			get {
				return (int)(ViewState["Max"] ?? 100);
			}
			set {
				ViewState["Max"] = value;
			}
		}

		/// <summary>
		/// The minimum value of the slider.
		/// Reference: http://api.jqueryui.com/slider/#option-min
		/// </summary>
		[WidgetOption("min", 0)]
		[DefaultValue(0)]
		[Description("The minimum value of the slider.")]
		[Category("Behavior")]
		public int Min {
			get {
				return (int)(ViewState["Min"] ?? 0);
			}
			set {
				ViewState["Min"] = value;
			}
		}

		/// <summary>
		/// This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.
		/// Reference: http://api.jqueryui.com/slider/#option-orientation
		/// </summary>
		[WidgetOption("orientation", "horizontal")]
		[DefaultValue("horizontal")]
		[Description("This option determines whether the slider has the min at the left, the max at the right or the min at the bottom, the max at the top. Possible values: 'horizontal', 'vertical'.")]
		[Category("Appearance")]
		public string Orientation {
			get {
				return (string)(ViewState["Orientation"] ?? "horizontal");
			}
			set {
				ViewState["Orientation"] = value;
			}
		}

		/// <summary>
		/// If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.
		/// Reference: http://api.jqueryui.com/slider/#option-range
		/// </summary>
		[WidgetOption("range", false)]
		[DefaultValue(false)]
		[Description("If set to true, the slider will detect if you have two handles and create a stylable range element between these two. Two other possible values are 'min' and 'max'. A min range goes from the slider min to one handle. A max range goes from one handle to the slider max.")]
		[Category("Appearance")]
		[TypeConverter(typeof(StringToObjectConverter))]
		public dynamic Range {
			get {
				return ViewState["Range"] ?? false;
			}
			set {
				ViewState["Range"] = value;
			}
		}

		/// <summary>
		/// Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.
		/// Reference: http://api.jqueryui.com/slider/#option-step
		/// </summary>
		[WidgetOption("step", 1)]
		[DefaultValue(1)]
		[Description("Determines the size or amount of each interval or step the slider takes between min and max. The full specified value range of the slider (max - min) needs to be evenly divisible by the step.")]
		[Category("Behavior")]
		public int Step {
			get {
				return (int)(ViewState["Step"] ?? 1);
			}
			set {
				ViewState["Step"] = value;
			}
		}

		/// <summary>
		/// Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.
		/// Reference: http://api.jqueryui.com/slider/#option-value
		/// </summary>
		[WidgetOption("value", 0)]
		[Category("Data")]
		[DefaultValue(0)]
		[Description("Determines the value of the slider, if there's only one handle. If there is more than one handle, determines the value of the first handle.")]
		public int Value {
			get {
				return (int)(ViewState["Value"] ?? 0);
			}
			set {
				ViewState["Value"] = value;
			}
		}

		/// <summary>
		/// This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.
		/// Reference: http://api.jqueryui.com/slider/#option-values
		/// </summary>
		[WidgetOption("values", null)]
		[Category("Data")]
		[DefaultValue(null)]
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Description("This option can be used to specify multiple handles. If range is set to true, the length of 'values' should be 2.")]
		public int[] Values {
			get {
				return (int[])ViewState["Values"];
			}
			set {
				ViewState["Values"] = value;
			}
		}

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered on slide stop, or if the value is changed programmatically (by the value method). Takes arguments event and ui. Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.
		/// Reference: http://api.jqueryui.com/slider/#event-change
		/// </summary>
		[WidgetEvent("change", AutoPostBack = true, DataChangedHandler = true)]
		[Description("This event is triggered on slide stop, or if the value is changed programmatically (by the value method). Takes arguments event and ui. Use event.orginalEvent to detect whether the value changed by mouse, keyboard, or programmatically. Use ui.value (single-handled sliders) to obtain the value of the current handle, $(this).slider('values', index) to get another handle's value.")]
		[Category("Action")]
		public event EventHandler ValueChanged {
			add {
				Events.AddHandler(_changeEvent, value);
			}
			remove {
				Events.RemoveHandler(_changeEvent, value);
			}
		}

		#endregion

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}

		protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
			var initialValue = Value;
			// TODO: Perhaps base LoadPostData can return a value indicating whether anything changed and 
			//       concrete types can decide to propagate that or not
			base.LoadPostData(postDataKey, postCollection);
			return initialValue != Value;
		}

		protected override void RaisePostDataChangedEvent() {
			base.RaisePostDataChangedEvent();
			OnValueChanged(EventArgs.Empty);
		}

		protected virtual void OnValueChanged(EventArgs e) {
			var handler = Events[_changeEvent] as EventHandler;
			if(handler != null) {
				handler(this, e);
			}
		}
	}
}