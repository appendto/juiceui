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
	/// Extend a TextBox with jQuery UI Autocomplete http://jqueryui.com/demos/autocomplete/
	/// </summary>
	[TargetControlType(typeof(TextBox))]
	[WidgetEvent("create")]
	[WidgetEvent("search")]
	[WidgetEvent("open")]
	[WidgetEvent("focus")]
	[WidgetEvent("close")]
	public class Autocomplete : JuiceExtender {

		public Autocomplete() : base("autocomplete") { }

		#region Widget Options

		/// <summary>
		/// Which element the menu should be appended to.
		/// Reference: http://jqueryui.com/demos/autocomplete/#appendTo
		/// </summary>
		[WidgetOption("appendTo", "body")]
		[Category("Behavior")]
		[Description("Which element the menu should be appended to.\nReference: http://jqueryui.com/demos/autocomplete/#appendTo")]
		public string AppendTo { get; set; }

		/// <summary>
		/// If set to true the first item will be automatically focused.
		/// Reference: http://jqueryui.com/demos/autocomplete/#autoFocus
		/// </summary>
		[WidgetOption("autoFocus", false)]
		[Category("Behavior")]
		[Description("If set to true the first item will be automatically focused.\nReference: http://jqueryui.com/demos/autocomplete/#autoFocus")]
		public bool AutoFocus { get; set; }

		/// <summary>
		/// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
		/// Reference: http://jqueryui.com/demos/autocomplete/#delay
		/// </summary>
		[WidgetOption("delay", 300)]
		[Category("Behavior")]
		[Description("The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.\nReference: http://jqueryui.com/demos/autocomplete/#delay")]
		public int Delay { get; set; }

		/// <summary>
		/// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
		/// Reference: http://jqueryui.com/demos/autocomplete/#minLength
		/// </summary>
		[WidgetOption("minLength", 1)]
		[Category("Key")]
		[Description("The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.\nReference: http://jqueryui.com/demos/autocomplete/#minLength")]
		public int MinLength { get; set; }

		/// <summary>
		/// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.
		/// Reference: http://jqueryui.com/demos/autocomplete/#position
		/// </summary>
		[WidgetOption("position", "{}", Eval = true)]
		[Category("Layout")]
		[Description("Identifies the position of the Autocomplete widget in relation to the associated input element. The \"of\" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.\nReference: http://jqueryui.com/demos/autocomplete/#position")]
		public string Position { get; set; }

		/// <summary>
		/// Defines the data to use, must be specified. See Overview section for more details, and look at the various demos.
		/// Reference: http://jqueryui.com/demos/autocomplete/#source
		/// </summary>
		[WidgetOption("source", null)]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[Description("Defines the data to use, must be specified. See Overview section for more details, and look at the various demos.\nReference: http://jqueryui.com/demos/autocomplete/#source")]
		public string[] Source { get; set; }

		#endregion

		#region Widget Events

		/// <summary>
		/// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.
		/// Reference: http://jqueryui.com/demos/autocomplete/#select
		/// </summary>
		[WidgetEvent("select")]
		[Category("Action")]
		[Description("Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.\nReference: http://jqueryui.com/demos/autocomplete/#select")]
		public event EventHandler Select;

		/// <summary>
		/// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
		/// Reference: http://jqueryui.com/demos/autocomplete/#change
		/// </summary>
		[WidgetEvent("change")]
		[Category("Action")]
		[Description("Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.\nReference: http://jqueryui.com/demos/autocomplete/#change")]
		public event EventHandler Change;

		#endregion

	}
}