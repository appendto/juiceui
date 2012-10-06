using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Juice.Framework;

namespace Juice {

	/// <summary>
	/// Extend a Control with the jQuery UI Selectable behavior http://api.jqueryui.com/selectable/
	/// </summary>
	[TargetControlType(typeof(WebControl))]
	[TargetControlType(typeof(System.Web.UI.HtmlControls.HtmlControl))]
	[WidgetEvent("create")]
	[WidgetEvent("selecting")]
	[WidgetEvent("start")]
	[WidgetEvent("stop")]
	[WidgetEvent("unselecting")]
	public class Selectable : JuiceExtender {

		public Selectable() : base("selectable") { }

		#region Widget Options

		/// <summary>
		/// This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.
		/// Reference: http://api.jqueryui.com/selectable/#option-autoRefresh
		/// </summary>
		[WidgetOption("autoRefresh", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("This determines whether to refresh (recalculate) the position and size of each selectee at the beginning of each select operation. If you have many many items, you may want to set this to false and call the refresh method manually.")]
		public bool AutoRefresh { get; set; }

		/// <summary>
		/// Prevents selecting if you start on elements matching the selector.
		/// Reference: http://api.jqueryui.com/selectable/#option-cancel
		/// </summary>
		[WidgetOption("cancel", ":input,option")]
		[Category("Appearance")]
		[DefaultValue(":input,option")]
		[Description("Prevents selecting if you start on elements matching the selector.")]
		public string Cancel { get; set; }

		/// <summary>
		/// Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.
		/// Reference: http://api.jqueryui.com/selectable/#option-delay
		/// </summary>
		[WidgetOption("delay", 0)]
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Time in milliseconds to define when the selecting should start. It helps preventing unwanted selections when clicking on an element.")]
		public int Delay { get; set; }

		/// <summary>
		/// Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.
		/// Reference: http://api.jqueryui.com/selectable/#option-distance
		/// </summary>
		[WidgetOption("distance", 0)]
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Tolerance, in pixels, for when selecting should start. If specified, selecting will not start until after mouse is dragged beyond distance.")]
		public int Distance { get; set; }

		/// <summary>
		/// The matching child elements will be made selectees (able to be selected).
		/// Reference: http://api.jqueryui.com/selectable/#option-filter
		/// </summary>
		[WidgetOption("filter", "*")]
		[Category("Behavior")]
		[DefaultValue("*")]
		[Description("The matching child elements will be made selectees (able to be selected).")]
		public string Filter { get; set; }

		/// <summary>
		/// Possible values: 'touch', 'fit'.
		/// Reference: http://api.jqueryui.com/selectable/#option-tolerance
		/// </summary>
		[WidgetOption("tolerance", "touch")]
		[Category("Behavior")]
		[DefaultValue("touch")]
		[Description("Possible values: 'touch', 'fit'.")]
		public string Tolerance { get; set; }

		#endregion

		#region Widget Events
	
		/// <summary>
		/// This event is triggered at the end of the select operation, on each element added to the selection.
		/// Reference: http://api.jqueryui.com/selectable/#event-selected
		/// </summary>
		[WidgetEvent("selected")]
		[Category("Action")]
		[Description("This event is triggered at the end of the select operation, on each element added to the selection.")]
		public event EventHandler Selected;
		
		/// <summary>
		/// This event is triggered at the end of the select operation, on each element removed from the selection.
		/// Reference: http://api.jqueryui.com/selectable/#event-unselected
		/// </summary>
		[WidgetEvent("unselected")]
		[Category("Action")]
		[Description("This event is triggered at the end of the select operation, on each element removed from the selection.")]
		public event EventHandler Unselected;

		#endregion

	}
}