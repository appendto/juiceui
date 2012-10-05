using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Juice.Framework;


namespace Juice {
	[TargetControlType(typeof(WebControl))]
	public class Position : JuiceExtender {

		#region Widget Options

		/// <summary>
		/// Defines which position on the element being positioned to align with the target element: "horizontal vertical" alignment. A single value such as "right" will default to "right center", "top" will default to "center top" (following CSS convention). Acceptable values: "top", "center", "bottom", "left", "right". Example: "left top" or "center center"
		/// Reference: http://jqueryui.com/demos/position/#my
		/// </summary>
		[WidgetOption("my", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Defines which position on the element being positioned to align with the target element: \"horizontal vertical\" alignment. A single value such as \"right\" will default to \"right center\", \"top\" will default to \"center top\" (following CSS convention). Acceptable values: \"top\", \"center\", \"bottom\", \"left\", \"right\". Example: \"left top\" or \"center center\"")]
		public string My { get; set; }

		/// <summary>
		/// Defines which position on the target element to align the positioned element against: "horizontal vertical" alignment. A single value such as "right" will default to "right center", "top" will default to "center top" (following CSS convention). Acceptable values: "top", "center", "bottom", "left", "right". Example: "left top" or "center center"
		/// Reference: http://jqueryui.com/demos/position/#at
		/// </summary>
		[WidgetOption("at", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Defines which position on the target element to align the positioned element against: \"horizontal vertical\" alignment. A single value such as \"right\" will default to \"right center\", \"top\" will default to \"center top\" (following CSS convention). Acceptable values: \"top\", \"center\", \"bottom\", \"left\", \"right\". Example: \"left top\" or \"center center\"")]
		public string At { get; set; }

		/// <summary>
		/// Element to position against. If you provide a selector, the first matching element will be used. If you provide a jQuery object, the first element will be used. If you provide an event object, the pageX and pageY properties will be used. Example: "#top-menu"
		/// Reference: http://jqueryui.com/demos/position/#of
		/// </summary>
		[WidgetOption("of", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("Element to position against. If you provide a selector, the first matching element will be used. If you provide a jQuery object, the first element will be used. If you provide an event object, the pageX and pageY properties will be used. Example: \"#top-menu\"")]
		public string Of { get; set; }

		[Obsolete("The offset option has been deprecated in jQuery UI 1.9 and offsets have been merged into the my and at options. Use \"at\" and \"my\" options instead.", true)]
		public string Offset { get; set; }

		/// <summary>
		/// When the positioned element overflows the window in some direction, move it to an alternative position. Similar to my and at, this accepts a single value or a pair for horizontal/vertical, eg. "flip", "fit", "fit flip", "fit none".
		/// Reference: http://jqueryui.com/demos/position/#collision
		/// </summary>
		[WidgetOption("collision", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("When the positioned element overflows the window in some direction, move it to an alternative position. Similar to my and at, this accepts a single value or a pair for horizontal/vertical, eg. \"flip\", \"fit\", \"fit flip\", \"fit none\".")]
		public string Collision { get; set; }

		/// <summary>
		/// When specified the actual property setting is delegated to this callback. Receives a single parameter which is a hash of top and left values for the position that should be set.
		/// Reference: http://jqueryui.com/demos/position/#using
		/// </summary>
		[WidgetOption("using", null)]
		[Category("Behavior")]
		[DefaultValue(null)]
		[Description("When specified the actual property setting is delegated to this callback. Receives a single parameter which is a hash of top and left values for the position that should be set.")]
		public string Using { get; set; }

		#endregion

		public Position() : base("position") {
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			if(Of != null && FindControl(Of) != null) {
				Of = "#" + FindControl(Of).ClientID;
			}
		}
	}
}
