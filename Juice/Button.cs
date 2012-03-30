using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Juice.Framework;

namespace Juice {

	/// <summary>
	/// Extend a TextBox with the jQuery UI Button http://jqueryui.com/demos/button/
	/// </summary>
	/// <remarks>Click Events should be handled on the extended control, natively.</remarks>
	[TargetControlType(typeof(HtmlAnchor))]
	[TargetControlType(typeof(HtmlGenericControl))] // supporting HtmlGenericControl to allow people to use on <div runat="server"/>
	[TargetControlType(typeof(HtmlButton))]
	[TargetControlType(typeof(HtmlInputButton))]
	[TargetControlType(typeof(Button))]
	[TargetControlType(typeof(LinkButton))]
	[WidgetEvent("create")]
	public class Button : JuiceExtender {

		public Button() : base("button") { }

		public Button(String widgetName) : base(widgetName) { } // adds support for Buttonset class.

		#region Widget Options

		/// <summary>
		/// Whether to show any text - when set to false (display no text), icons (see icons option) must be enabled, otherwise it'll be ignored.
		/// Reference: http://jqueryui.com/demos/button/#text
		/// </summary>
		[WidgetOption("text", true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Whether to show any text - when set to false (display no text), icons (see icons option) must be enabled, otherwise it'll be ignored.")]
		public bool Text { get; set; }

		/// <summary>
		/// Icons to display, with or without text (see text option). The primary icon is displayed by default on the left of the label text, the secondary by default is on the right. Value for the primary and secondary properties must be a classname (String), eg. "ui-icon-gear". For using only one icon: icons: {primary:'ui-icon-locked'}. For using two icons: icons: {primary:'ui-icon-gear',secondary:'ui-icon-triangle-1-s'}
		/// Reference: http://jqueryui.com/demos/button/#icons
		/// </summary>
		[WidgetOption("icons", "{}", Eval = true)]
		[TypeConverter(typeof(Framework.TypeConverters.JsonObjectConverter))]
		[Category("Appearance")]
		[DefaultValue("{}")]
		[Description("Icons to display, with or without text (see text option). The primary icon is displayed by default on the left of the label text, the secondary by default is on the right. Value for the primary and secondary properties must be a classname (String), eg. \"ui-icon-gear\". For using only one icon: icons: {primary:'ui-icon-locked'}. For using two icons: icons: {primary:'ui-icon-gear',secondary:'ui-icon-triangle-1-s'}")]
		public string Icons { get; set; }

		/// <summary>
		/// Text to show on the button. When not specified (null), the element's html content is used, or its value attribute when it's an input element of type submit or reset; or the html content of the associated label element if its an input of type radio or checkbox
		/// Reference: http://jqueryui.com/demos/button/#label
		/// </summary>
		[WidgetOption("label", null)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Description("Text to show on the button. When not specified (null), the element's html content is used, or its value attribute when it's an input element of type submit or reset; or the html content of the associated label element if its an input of type radio or checkbox")]
		public string Label { get; set; }

		#endregion
	}
}