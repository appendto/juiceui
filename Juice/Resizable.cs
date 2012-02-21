using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice {
	/// <summary>
	/// Extend a Panel with the jQuery UI Resizable behavior http://jqueryui.com/demos/resizable/
	/// </summary>
	[TargetControlType(typeof(Panel))]
	[WidgetEvent("create")]
	[WidgetEvent("start")]
	[WidgetEvent("resize")]
	public class Resizable : JuiceExtender {

		#region "Widget Options"

		/// <summary>
		/// Resize these elements synchronous when resizing.
		/// Reference: http://jqueryui.com/demos/resizable/#option-alsoResize
		/// </summary>
		[WidgetOption("alsoResize", null)] // Selector (String)
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Resize these elements synchronous when resizing.")]
		public String AlsoResize { get; set; }

		/// <summary>
		/// Animates to the final size after resizing.
		/// Reference: http://jqueryui.com/demos/resizable/#option-animate
		/// </summary>
		[WidgetOption("animate", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Animates to the final size after resizing.")]
		public Boolean Animate { get; set; }

		/// <summary>
		/// Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.
		/// Reference: http://jqueryui.com/demos/resizable/#option-animateDuration
		/// </summary>
		[WidgetOption("animateDuration", "slow")] // Integer, String
		[Category("Behavior")]
		[DefaultValue("slow")]
		[Description("Duration time for animating, in milliseconds. Other possible values: 'slow', 'normal', 'fast'.")]
		public dynamic AnimateDuration { get; set; }

		/// <summary>
		/// Easing effect for animating.
		/// Reference: http://jqueryui.com/demos/resizable/#option-animateEasing
		/// </summary>
		[WidgetOption("animateEasing", "swing")]
		[Category("Behavior")]
		[DefaultValue("swing")]
		[Description("Easing effect for animating.")]
		public String AnimateEasing { get; set; }

		/// <summary>
		/// If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.
		/// Reference: http://jqueryui.com/demos/resizable/#option-aspectRatio
		/// </summary>
		[WidgetOption("aspectRatio", false)] //Boolean, Float
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, resizing is constrained by the original aspect ratio. Otherwise a custom aspect ratio can be specified, such as 9 / 16, or 0.5.")]
		public dynamic AspectRatio { get; set; }

		/// <summary>
		/// If set to true, automatically hides the handles except when the mouse hovers over the element.
		/// Reference: http://jqueryui.com/demos/resizable/#option-autoHide
		/// </summary>
		[WidgetOption("autoHide", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, automatically hides the handles except when the mouse hovers over the element.")]
		public Boolean AutoHide { get; set; }

		/// <summary>
		/// Prevents resizing if you start on elements matching the selector.
		/// Reference: http://jqueryui.com/demos/resizable/#option-cancel
		/// </summary>
		[WidgetOption("cancel", ":input,option")]
		[Category("Behavior")]
		[DefaultValue(":input,option")]
		[Description("Prevents resizing if you start on elements matching the selector.")]
		public String Cancel { get; set; }

		/// <summary>
		/// Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.
		/// Reference: http://jqueryui.com/demos/resizable/#option-containment
		/// </summary>
		[WidgetOption("containment", null)] // Selector (String)
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Constrains resizing to within the bounds of the specified element. Possible values: 'parent', 'document', a DOMElement, or a Selector.")]
		public String Containment { get; set; }

		/// <summary>
		/// Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.
		/// Reference: http://jqueryui.com/demos/resizable/#option-delay
		/// </summary>
		[WidgetOption("delay", 0)]
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Tolerance, in milliseconds, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond duration. This can help prevent unintended resizing when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.
		/// Reference: http://jqueryui.com/demos/resizable/#option-distance
		/// </summary>
		[WidgetOption("distance", 1)]
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Tolerance, in pixels, for when resizing should start. If specified, resizing will not start until after mouse is moved beyond distance. This can help prevent unintended resizing when clicking on an element.")]
		public int Distance { get; set; }

		/// <summary>
		/// If set to true, a semi-transparent helper element is shown for resizing.
		/// Reference: http://jqueryui.com/demos/resizable/#option-ghost
		/// </summary>
		[WidgetOption("ghost", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true, a semi-transparent helper element is shown for resizing.")]
		public Boolean Ghost { get; set; }

		/// <summary>
		/// Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]
		/// Reference: http://jqueryui.com/demos/resizable/#option-grid
		/// </summary>
		[WidgetOption("grid", null)] // Array, eg. [50, 50]		
		[TypeConverter(typeof(Int32ArrayConverter))]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Snaps the resizing element to a grid, every x and y pixels. Array values: [x, y]")]
		public int[] Grid { get; set; }

		/// <summary>
		/// If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin.
		/// Reference: http://jqueryui.com/demos/resizable/#option-handles
		/// </summary>
		[WidgetOption("handles", "e, s, se")]
		[Category("Appearance")]
		[DefaultValue("e, s, se")]
		[Description("If specified as a string, should be a comma-split list of any of the following: 'n, e, s, w, ne, se, sw, nw, all'. The necessary handles will be auto-generated by the plugin.")]
		public String Handles { get; set; }

		/// <summary>
		/// This is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.
		/// Reference: http://jqueryui.com/demos/resizable/#option-helper
		/// </summary>
		[WidgetOption("helper", null)] // String
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("his is the css class that will be added to a proxy element to outline the resize during the drag of the resize handle. Once the resize is complete, the original element is sized.")]
		public String Helper { get; set; }

		/// <summary>
		/// This is the maximum height the resizable should be allowed to resize to.
		/// Reference: http://jqueryui.com/demos/resizable/#option-maxHeight
		/// </summary>
		[WidgetOption("maxHeight", 0)]
		[Category("Layout")]
		[DefaultValue(0)]
		[Description("This is the maximum height the resizable should be allowed to resize to.")]
		public int MaxHeight { get; set; }

		/// <summary>
		/// This is the maximum width the resizable should be allowed to resize to.
		/// Reference: http://jqueryui.com/demos/resizable/#option-maxWidth
		/// </summary>	
		[WidgetOption("maxWidth", 0)]
		[Category("Layout")]
		[DefaultValue(0)]
		[Description("This is the maximum width the resizable should be allowed to resize to.")]
		public int MaxWidth { get; set; }

		/// <summary>
		/// This is the minimum height the resizable should be allowed to resize to.
		/// Reference: http://jqueryui.com/demos/resizable/#option-minHeight
		/// </summary>
		[WidgetOption("minHeight", 10)]
		[Category("Layout")]
		[DefaultValue(10)]
		[Description("This is the minimum height the resizable should be allowed to resize to.")]
		public int MinHeight { get; set; }

		/// <summary>
		/// This is the minimum width the resizable should be allowed to resize to.
		/// Reference: http://jqueryui.com/demos/resizable/#option-minWidth
		/// </summary>
		[WidgetOption("minWidth", 10)]
		[Category("Layout")]
		[DefaultValue(10)]
		[Description("This is the minimum width the resizable should be allowed to resize to.")]
		public int MinWidth { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// This event is triggered at the end of a resize operation.
		/// Reference: http://jqueryui.com/demos/resizable/#event-stop
		/// </summary>
		[WidgetEvent("stop")]
		[Category("Action")]
		[Description("This event is triggered at the end of a resize operation.")]
		public event EventHandler Drop;

		#endregion

		public Resizable() : base("resizable") { }

	}
}
