using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Juice.Framework;

namespace Juice {
	/// <summary>
	/// Extend a TextBox with the jQuery UI Datepicker http://jqueryui.com/demos/datepicker/
	/// </summary>
	[TargetControlType(typeof(TextBox))]
	[WidgetEvent("create")]
	[WidgetEvent("beforeShow")]
	// TODO: This event causes a failure when pushing through amplify pub/sub because
	//       the widget is expecting it to return a value and fails when it doesn't
	//[WidgetEvent("beforeShowDay")]
	[WidgetEvent("onChangeMonthYear")]
	[WidgetEvent("onClose")]
	public class Datepicker : JuiceExtender {

		public Datepicker() : base("datepicker") {

		}

		#region Widget Options

		/// <summary>
		/// The jQuery selector for another field that is to be updated with the selected date from the datepicker. Use the altFormat setting to change the format of the date within this field. Leave as blank for no alternate field.
		/// Reference: http://jqueryui.com/demos/datepicker/#altField
		/// </summary>
		[WidgetOption("altField", "")]
		[Category("Behavior")]
		[DefaultValue("")]
		[Description("The jQuery selector for another field that is to be updated with the selected date from the datepicker. Use the altFormat setting to change the format of the date within this field. Leave as blank for no alternate field.")]
		public string AltField { get; set; }

		/// <summary>
		/// The dateFormat to be used for the altField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the formatDate function
		/// Reference: http://jqueryui.com/demos/datepicker/#altFormat
		/// </summary>
		[WidgetOption("altFormat", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The dateFormat to be used for the altField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. For a full list of the possible formats see the formatDate function")]
		public string AltFormat { get; set; }

		/// <summary>
		/// The text to display after each date field, e.g. to show the required format.
		/// Reference: http://jqueryui.com/demos/datepicker/#appendText
		/// </summary>
		[WidgetOption("appendText", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The text to display after each date field, e.g. to show the required format.")]
		public string AppendText { get; set; }

		/// <summary>
		/// Set to true to automatically resize the input field to accomodate dates in the current dateFormat.
		/// Reference: http://jqueryui.com/demos/datepicker/#autoSize
		/// </summary>
		[WidgetOption("autoSize", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Set to true to automatically resize the input field to accomodate dates in the current dateFormat.")]
		public bool AutoSize { get; set; }

		/// <summary>
		/// The URL for the popup button image. If set, buttonText becomes the alt value and is not directly displayed.
		/// Reference: http://jqueryui.com/demos/datepicker/#buttonImage
		/// </summary>
		[WidgetOption("buttonImage", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The URL for the popup button image. If set, buttonText becomes the alt value and is not directly displayed.")]
		public string ButtonImage { get; set; }

		/// <summary>
		/// Set to true to place an image after the field to use as the trigger without it appearing on a button.
		/// Reference: http://jqueryui.com/demos/datepicker/#buttonImageOnly
		/// </summary>
		[WidgetOption("buttonImageOnly", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Set to true to place an image after the field to use as the trigger without it appearing on a button.")]
		public bool ButtonImageOnly { get; set; }

		/// <summary>
		/// The text to display on the trigger button. Use in conjunction with showOn equal to 'button' or 'both'.
		/// Reference: http://jqueryui.com/demos/datepicker/#buttonText
		/// </summary>
		[WidgetOption("buttonText", "...")]
		[Category("Appearance")]
		[DefaultValue("...")]
		[Description("The text to display on the trigger button. Use in conjunction with showOn equal to 'button' or 'both'.")]
		public string ButtonText { get; set; }

		/// <summary>
		/// A function to calculate the week of the year for a given date. The default implementation uses the ISO 8601 definition: weeks start on a Monday; the first week of the year contains the first Thursday of the year.
		/// Reference: http://jqueryui.com/demos/datepicker/#calculateWeek
		/// </summary>
		[WidgetOption("calculateWeek", "$.datepicker.iso8601Week", Eval = true)]
		[Category("")]
		[DefaultValue("$.datepicker.iso8601Week")]
		[Description("A function to calculate the week of the year for a given date. The default implementation uses the ISO 8601 definition: weeks start on a Monday; the first week of the year contains the first Thursday of the year.")]
		public string CalculateWeek { get; set; }

		/// <summary>
		/// Allows you to change the month by selecting from a drop-down list. You can enable this feature by setting the attribute to true.
		/// Reference: http://jqueryui.com/demos/datepicker/#changeMonth
		/// </summary>
		[WidgetOption("changeMonth", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Allows you to change the month by selecting from a drop-down list. You can enable this feature by setting the attribute to true.")]
		public bool ChangeMonth { get; set; }

		/// <summary>
		/// Allows you to change the year by selecting from a drop-down list. You can enable this feature by setting the attribute to true. Use the yearRange option to control which years are made available for selection.
		/// Reference: http://jqueryui.com/demos/datepicker/#changeYear
		/// </summary>
		[WidgetOption("changeYear", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Allows you to change the year by selecting from a drop-down list. You can enable this feature by setting the attribute to true. Use the yearRange option to control which years are made available for selection.")]
		public bool ChangeYear { get; set; }

		/// <summary>
		/// The text to display for the close link. This attribute is one of the regionalisation attributes. Use the showButtonPanel to display this button.
		/// Reference: http://jqueryui.com/demos/datepicker/#closeText
		/// </summary>
		[WidgetOption("closeText", "Done")]
		[Category("Appearance")]
		[DefaultValue("Done")]
		[Description("The text to display for the close link. This attribute is one of the regionalisation attributes. Use the showButtonPanel to display this button.")]
		public string CloseText { get; set; }

		/// <summary>
		/// When true entry in the input field is constrained to those characters allowed by the current dateFormat.
		/// Reference: http://jqueryui.com/demos/datepicker/#constrainInput
		/// </summary>
		[WidgetOption("constrainInput", true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("When true entry in the input field is constrained to those characters allowed by the current dateFormat.")]
		public bool ConstrainInput { get; set; }

		/// <summary>
		/// The text to display for the current day link. This attribute is one of the regionalisation attributes. Use the showButtonPanel to display this button.
		/// Reference: http://jqueryui.com/demos/datepicker/#currentText
		/// </summary>
		[WidgetOption("currentText", "Today")]
		[Category("Appearance")]
		[DefaultValue("Today")]
		[Description("The text to display for the current day link. This attribute is one of the regionalisation attributes. Use the showButtonPanel to display this button.")]
		public string CurrentText { get; set; }

		/// <summary>
		/// The format for parsed and displayed dates. This attribute is one of the regionalisation attributes. For a full list of the possible formats see the formatDate function.
		/// Reference: http://jqueryui.com/demos/datepicker/#dateFormat
		/// </summary>
		[WidgetOption("dateFormat", "mm/dd/yy")]
		[Category("Format")]
		[DefaultValue("mm/dd/yy")]
		[Description("The format for parsed and displayed dates. This attribute is one of the regionalisation attributes. For a full list of the possible formats see the formatDate function.")]
		public string DateFormat { get; set; }

		/// <summary>
		/// The list of long day names, starting from Sunday, for use as requested via the dateFormat setting. They also appear as popup hints when hovering over the corresponding column headings. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#dayNames
		/// </summary>
		[WidgetOption("dayNames", new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" })]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[DefaultValue("Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
		[Description("The list of long day names, starting from Sunday, for use as requested via the dateFormat setting. They also appear as popup hints when hovering over the corresponding column headings. This attribute is one of the regionalisation attributes.")]
		public string[] DayNames { get; set; }

		/// <summary>
		/// The list of minimised day names, starting from Sunday, for use as column headers within the datepicker. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#dayNamesMin
		/// </summary>
		[WidgetOption("dayNamesMin", new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" })]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[DefaultValue("Su, Mo, Tu, We, Th, Fr, Sa")]
		[Description("The list of minimised day names, starting from Sunday, for use as column headers within the datepicker. This attribute is one of the regionalisation attributes.")]
		public string[] DayNamesMin { get; set; }

		/// <summary>
		/// The list of abbreviated day names, starting from Sunday, for use as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#dayNamesShort
		/// </summary>
		[WidgetOption("dayNamesShort", new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" })]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[DefaultValue("Sun, Mon, Tue, Wed, Thu, Fri, Sat")]
		[Description("The list of abbreviated day names, starting from Sunday, for use as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.")]
		public string[] DayNamesShort { get; set; }

		/// <summary>
		/// Set the date to highlight on first opening if the field is blank. Specify either an actual date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null for today.
		/// Reference: http://jqueryui.com/demos/datepicker/#defaultDate
		/// </summary>
		[WidgetOption("defaultDate", null)]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Set the date to highlight on first opening if the field is blank. Specify either an actual date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null for today.")]
		public string DefaultDate { get; set; }

		/// <summary>
		/// Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds ("slow", "normal", "fast").
		/// Reference: http://jqueryui.com/demos/datepicker/#duration
		/// </summary>
		[WidgetOption("duration", "normal")]
		[Category("Behavior")]
		[DefaultValue("normal")]
		[Description("Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds (\"slow\", \"normal\", \"fast\").")]
		public string Duration { get; set; }

		/// <summary>
		/// Set the first day of the week: Sunday is 0, Monday is 1, ... This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#firstDay
		/// </summary>
		[WidgetOption("firstDay", 0)]
		[Category("Appearance")]
		[DefaultValue(0)]
		[Description("Set the first day of the week: Sunday is 0, Monday is 1, ... This attribute is one of the regionalisation attributes.")]
		public int FirstDay { get; set; }

		/// <summary>
		/// When true the current day link moves to the currently selected date instead of today.
		/// Reference: http://jqueryui.com/demos/datepicker/#gotoCurrent
		/// </summary>
		[WidgetOption("gotoCurrent", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("When true the current day link moves to the currently selected date instead of today.")]
		public bool GotoCurrent { get; set; }

		/// <summary>
		/// Normally the previous and next links are disabled when not applicable (see minDate/maxDate). You can hide them altogether by setting this attribute to true.
		/// Reference: http://jqueryui.com/demos/datepicker/#hideIfNoPrevNext
		/// </summary>
		[WidgetOption("hideIfNoPrevNext", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("Normally the previous and next links are disabled when not applicable (see minDate/maxDate). You can hide them altogether by setting this attribute to true.")]
		public bool HideIfNoPrevNext { get; set; }

		/// <summary>
		/// True if the current language is drawn from right to left. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#isRTL
		/// </summary>
		[WidgetOption("isRTL", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("True if the current language is drawn from right to left. This attribute is one of the regionalisation attributes.")]
		public bool IsRTL { get; set; }

		/// <summary>
		/// Set a maximum selectable date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +1w'), or null for no limit.
		/// Reference: http://jqueryui.com/demos/datepicker/#maxDate
		/// </summary>
		[WidgetOption("maxDate", null)]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Set a maximum selectable date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +1w'), or null for no limit.")]
		public string MaxDate { get; set; }

		/// <summary>
		/// Set a minimum selectable date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '-1y -1m'), or null for no limit.
		/// Reference: http://jqueryui.com/demos/datepicker/#minDate
		/// </summary>
		[WidgetOption("minDate", null)]
		[Category("Data")]
		[DefaultValue(null)]
		[Description("Set a minimum selectable date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '-1y -1m'), or null for no limit.")]
		public string MinDate { get; set; }

		/// <summary>
		/// The list of full month names, for use as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#monthNames
		/// </summary>
		[WidgetOption("monthNames", new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" })]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[DefaultValue("January, February, March, April, May, June, July, August, September, October, November, December")]
		[Description("The list of full month names, for use as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.")]
		public string[] MonthNames { get; set; }

		/// <summary>
		/// The list of abbreviated month names, as used in the month header on each datepicker and as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#monthNamesShort
		/// </summary>
		[WidgetOption("monthNamesShort", new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" })]
		[TypeConverter(typeof(StringArrayConverter))]
		[Category("Data")]
		[DefaultValue("Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec")]
		[Description("The list of abbreviated month names, as used in the month header on each datepicker and as requested via the dateFormat setting. This attribute is one of the regionalisation attributes.")]
		public string[] MonthNamesShort { get; set; }

		/// <summary>
		/// When true the formatDate function is applied to the prevText, nextText, and currentText values before display, allowing them to display the target month names for example.
		/// Reference: http://jqueryui.com/demos/datepicker/#navigationAsDateFormat
		/// </summary>
		[WidgetOption("navigationAsDateFormat", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("When true the formatDate function is applied to the prevText, nextText, and currentText values before display, allowing them to display the target month names for example.")]
		public bool NavigationAsDateFormat { get; set; }

		/// <summary>
		/// The text to display for the next month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.
		/// Reference: http://jqueryui.com/demos/datepicker/#nextText
		/// </summary>
		[WidgetOption("nextText", "Next")]
		[Category("Appearance")]
		[DefaultValue("Next")]
		[Description("The text to display for the next month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.")]
		public string NextText { get; set; }

		/// <summary>
		/// Set how many months to show at once. The value can be a straight integer, or can be a two-element array to define the number of rows and columns to display.
		/// Reference: http://jqueryui.com/demos/datepicker/#numberOfMonths
		/// </summary>
		[WidgetOption("numberOfMonths", 1)]
		[Category("Data")]
		[DefaultValue(1)]
		[Description("Set how many months to show at once. The value can be a straight integer, or can be a two-element array to define the number of rows and columns to display.")]
		public int NumberOfMonths { get; set; }

		/// <summary>
		/// The text to display for the previous month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.
		/// Reference: http://jqueryui.com/demos/datepicker/#prevText
		/// </summary>
		[WidgetOption("prevText", "Prev")]
		[Category("Appearance")]
		[DefaultValue("Prev")]
		[Description("The text to display for the previous month link. This attribute is one of the regionalisation attributes. With the standard ThemeRoller styling, this value is replaced by an icon.")]
		public string PrevText { get; set; }

		/// <summary>
		/// When true days in other months shown before or after the current month are selectable. This only applies if showOtherMonths is also true.
		/// Reference: http://jqueryui.com/demos/datepicker/#selectOtherMonths
		/// </summary>
		[WidgetOption("selectOtherMonths", false)]
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("When true days in other months shown before or after the current month are selectable. This only applies if showOtherMonths is also true.")]
		public bool SelectOtherMonths { get; set; }

		/// <summary>
		/// Set the cutoff year for determining the century for a date (used in conjunction with dateFormat 'y'). If a numeric value (0-99) is provided then this value is used directly. If a string value is provided then it is converted to a number and added to the current year. Once the cutoff year is calculated, any dates entered with a year value less than or equal to it are considered to be in the current century, while those greater than it are deemed to be in the previous century.
		/// Reference: http://jqueryui.com/demos/datepicker/#shortYearCutoff
		/// </summary>
		[WidgetOption("shortYearCutoff", "+10")]
		[Category("Behavior")]
		[DefaultValue("+10")]
		[Description("Set the cutoff year for determining the century for a date (used in conjunction with dateFormat 'y'). If a numeric value (0-99) is provided then this value is used directly. If a string value is provided then it is converted to a number and added to the current year. Once the cutoff year is calculated, any dates entered with a year value less than or equal to it are considered to be in the current century, while those greater than it are deemed to be in the previous century.")]
		public string ShortYearCutoff { get; set; }

		/// <summary>
		/// Set the name of the animation used to show/hide the datepicker. Use 'show' (the default), 'slideDown', 'fadeIn', any of the show/hide jQuery UI effects, or '' for no animation.
		/// Reference: http://jqueryui.com/demos/datepicker/#showAnim
		/// </summary>
		[WidgetOption("showAnim", "show")]
		[Category("Behavior")]
		[DefaultValue("show")]
		[Description("Set the name of the animation used to show/hide the datepicker. Use 'show' (the default), 'slideDown', 'fadeIn', any of the show/hide jQuery UI effects, or '' for no animation.")]
		public string ShowAnim { get; set; }

		/// <summary>
		/// Whether to show the button panel.
		/// Reference: http://jqueryui.com/demos/datepicker/#showButtonPanel
		/// </summary>
		[WidgetOption("showButtonPanel", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("Whether to show the button panel.")]
		public bool ShowButtonPanel { get; set; }

		/// <summary>
		/// Specify where in a multi-month display the current month shows, starting from 0 at the top/left.
		/// Reference: http://jqueryui.com/demos/datepicker/#showCurrentAtPos
		/// </summary>
		[WidgetOption("showCurrentAtPos", 0)]
		[Category("Appearance")]
		[DefaultValue(0)]
		[Description("Specify where in a multi-month display the current month shows, starting from 0 at the top/left.")]
		public int ShowCurrentAtPos { get; set; }

		/// <summary>
		/// Whether to show the month after the year in the header. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#showMonthAfterYear
		/// </summary>
		[WidgetOption("showMonthAfterYear", false)]
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("Whether to show the month after the year in the header. This attribute is one of the regionalisation attributes.")]
		public bool ShowMonthAfterYear { get; set; }

		/// <summary>
		/// Have the datepicker appear automatically when the field receives focus ('focus'), appear only when a button is clicked ('button'), or appear when either event takes place ('both').
		/// Reference: http://jqueryui.com/demos/datepicker/#showOn
		/// </summary>
		[WidgetOption("showOn", "focus")]
		[Category("Behavior")]
		[DefaultValue("focus")]
		[Description("Have the datepicker appear automatically when the field receives focus ('focus'), appear only when a button is clicked ('button'), or appear when either event takes place ('both').")]
		public string ShowOn { get; set; }

		/// <summary>
		/// If using one of the jQuery UI effects for showAnim, you can provide additional settings for that animation via this option.
		/// Reference: http://jqueryui.com/demos/datepicker/#showOptions
		/// </summary>
		[WidgetOption("showOptions", "{}", Eval = true)]
		[Category("Behavior")]
		[DefaultValue("{}")]
		[Description("If using one of the jQuery UI effects for showAnim, you can provide additional settings for that animation via this option.")]
		public String ShowOptions { get; set; }

		/// <summary>
		/// Display dates in other months (non-selectable) at the start or end of the current month. To make these days selectable use selectOtherMonths.
		/// Reference: http://jqueryui.com/demos/datepicker/#showOtherMonths
		/// </summary>
		[WidgetOption("showOtherMonths", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Display dates in other months (non-selectable) at the start or end of the current month. To make these days selectable use selectOtherMonths.")]
		public bool ShowOtherMonths { get; set; }

		/// <summary>
		/// When true a column is added to show the week of the year. The calculateWeek option determines how the week of the year is calculated. You may also want to change the firstDay option.
		/// Reference: http://jqueryui.com/demos/datepicker/#showWeek
		/// </summary>
		[WidgetOption("showWeek", false)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("When true a column is added to show the week of the year. The calculateWeek option determines how the week of the year is calculated. You may also want to change the firstDay option.")]
		public bool ShowWeek { get; set; }

		/// <summary>
		/// Set how many months to move when clicking the Previous/Next links.
		/// Reference: http://jqueryui.com/demos/datepicker/#stepMonths
		/// </summary>
		[WidgetOption("stepMonths", 1)]
		[Category("Behavior")]
		[DefaultValue(1)]
		[Description("Set how many months to move when clicking the Previous/Next links.")]
		public int StepMonths { get; set; }

		/// <summary>
		/// The text to display for the week of the year column heading. This attribute is one of the regionalisation attributes. Use showWeek to display this column.
		/// Reference: http://jqueryui.com/demos/datepicker/#weekHeader
		/// </summary>
		[WidgetOption("weekHeader", "Wk")]
		[Category("Appearance")]
		[DefaultValue("Wk")]
		[Description("The text to display for the week of the year column heading. This attribute is one of the regionalisation attributes. Use showWeek to display this column.")]
		public string WeekHeader { get; set; }

		/// <summary>
		/// Control the range of years displayed in the year drop-down: either relative to today's year (-nn:+nn), relative to the currently selected year (c-nn:c+nn), absolute (nnnn:nnnn), or combinations of these formats (nnnn:-nn). Note that this option only affects what appears in the drop-down, to restrict which dates may be selected use the minDate and/or maxDate options.
		/// Reference: http://jqueryui.com/demos/datepicker/#yearRange
		/// </summary>
		[WidgetOption("yearRange", "c-10:c+10")]
		[Category("Data")]
		[DefaultValue("c-10:c+10")]
		[Description("Control the range of years displayed in the year drop-down: either relative to today's year (-nn:+nn), relative to the currently selected year (c-nn:c+nn), absolute (nnnn:nnnn), or combinations of these formats (nnnn:-nn). Note that this option only affects what appears in the drop-down, to restrict which dates may be selected use the minDate and/or maxDate options.")]
		public string YearRange { get; set; }

		/// <summary>
		/// Additional text to display after the year in the month headers. This attribute is one of the regionalisation attributes.
		/// Reference: http://jqueryui.com/demos/datepicker/#yearSuffix
		/// </summary>
		[WidgetOption("yearSuffix", "")]
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("Additional text to display after the year in the month headers. This attribute is one of the regionalisation attributes.")]
		public string YearSuffix { get; set; }

		#endregion

		#region Widget Events
		
		/// <summary>
		/// Allows you to define your own event when the datepicker is selected. The function receives the selected date as text and the datepicker instance as parameters. this refers to the associated input field.
		/// Reference: http://jqueryui.com/demos/datepicker/#onSelect
		/// </summary>
		[WidgetEvent("onSelect")]
		[Category("Action")]
		[Description("Allows you to define your own event when the datepicker is selected. The function receives the selected date as text and the datepicker instance as parameters. this refers to the associated input field.")]
		public event EventHandler OnSelect;

		#endregion
	}
}