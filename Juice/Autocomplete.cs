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
		[DefaultValue("body")]
		[Description("Which element the menu should be appended to.")]
		public string AppendTo { get; set; }

		/// <summary>
		/// If set to true the first item will be automatically focused.
		/// Reference: http://jqueryui.com/demos/autocomplete/#autoFocus
		/// </summary>
		[WidgetOption("autoFocus", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("If set to true the first item will be automatically focused.")]
		public bool AutoFocus { get; set; }

		/// <summary>
		/// The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.
		/// Reference: http://jqueryui.com/demos/autocomplete/#delay
		/// </summary>
		[WidgetOption("delay", 300)]
		[Category("Behavior")]
		[DefaultValue(300)]
		[Description("The delay in milliseconds the Autocomplete waits after a keystroke to activate itself. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.")]
		public int Delay { get; set; }

		/// <summary>
		/// The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.
		/// Reference: http://jqueryui.com/demos/autocomplete/#minLength
		/// </summary>
		[WidgetOption("minLength", 1)]
		[Category("Key")]
		[DefaultValue(1)]
		[Description("The minimum number of characters a user has to type before the Autocomplete activates. Zero is useful for local data with just a few items. Should be increased when there are a lot of items, where a single character would match a few thousand items.")]
		public int MinLength { get; set; }

		/// <summary>
		/// Identifies the position of the Autocomplete widget in relation to the associated input element. The "of" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.
		/// Reference: http://jqueryui.com/demos/autocomplete/#position
		/// </summary>
		[WidgetOption("position", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Layout")]
		[DefaultValue("{}")]
		[Description("Identifies the position of the Autocomplete widget in relation to the associated input element. The \"of\" option defaults to the input element, but you can specify another element to position against. You can refer to the jQuery UI Position utility for more details about the various options.")]
		public string Position { get; set; }

		private String _sourceUrl = null;
		private String[] _source = null;

		/// <summary>
		/// Defines a data source url for the data to use. Source or SourceUrl must be specified.
		/// If both SourceUrl and Source are specified, Source will take priority.
		/// Reference: http://jqueryui.com/demos/autocomplete/#source
		/// </summary>
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Defines a data source url for the data to use. Source or SourceUrl must be specified. If both SourceUrl and Source are specified, Source will take priority.")]
		public String SourceUrl {
			get { return _sourceUrl; }
			set { this._sourceUrl = value; }
		}

		/// <summary>
		/// Defines the data to use. Source or SourceUrl must be specified.
		/// Reference: http://jqueryui.com/demos/autocomplete/#source
		/// </summary>
		[TypeConverter(typeof(Framework.TypeConverters.StringArrayConverter))]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Defines the data to use. Source or SourceUrl must be specified.")]
		public String[] Source {
			get { return this._source; }
			set { this._source = value; }
		}

		/// <summary>
		/// Internal container for the source option.
		/// </summary>
		/// <remarks>
		/// Yes, this is ugly. It's really ugly.
		/// This is (so far) the only instance where we have to do something like this.
		/// There's no way to differentiate between a string and an array of length(1) in control attributes.
		/// If we run across this scenario again, we should write a TypeDescriptorProvider that will pull Internal/Private properties
		/// or switch back to using PropertyInfo instead of PropertyDescriptors.
		/// </remarks>
		[WidgetOption("source", null)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public object Widget_Source {
			get {
				if(this._source != null) {
					return this._source;
				}
				return this._sourceUrl;
			}
			internal set {
				if(value is String[]) {
					this.Source = value as String[];
				}
				else if(value is String) {
					this.SourceUrl = value as String;
				}
			}
		}

		#endregion

		#region Widget Events

		/// <summary>
		/// Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.
		/// Reference: http://jqueryui.com/demos/autocomplete/#select
		/// </summary>
		[WidgetEvent("select")]
		[Category("Action")]
		[Description("Triggered when an item is selected from the menu; ui.item refers to the selected item. The default action of select is to replace the text field's value with the value of the selected item. Canceling this event prevents the value from being updated, but does not prevent the menu from closing.")]
		public event EventHandler Select;

		/// <summary>
		/// Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.
		/// Reference: http://jqueryui.com/demos/autocomplete/#change
		/// </summary>
		[WidgetEvent("change")]
		[Category("Action")]
		[Description("Triggered when the field is blurred, if the value has changed; ui.item refers to the selected item.")]
		public event EventHandler Change;

		#endregion

	}
}