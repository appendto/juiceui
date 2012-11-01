using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Select a date from a popup or inline calendar
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Datepicker if set to true.</param>
		/// <param name="altField">An input element that is to be updated with the selected date from the datepicker. Use the altFormat option to change the format of the date within this field. Leave as blank for no alternate field.</param>
		/// <param name="altFormat">The dateFormat to be used for the altField option. This allows one date format to be shown to the user for selection purposes, while a different format is actually sent behind the scenes. </param>
		/// <param name="appendText">The text to display after each date field, e.g., to show the required format.</param>
		/// <param name="autoSize">Set to true to automatically resize the input field to accommodate dates in the current dateFormat.</param>
		/// <param name="buttonImage">The URL for the popup button image. If set, the buttonText option becomes the alt value and is not directly displayed.</param>
		/// <param name="buttonImageOnly">Whether the button image should be rendered by itself instead of inside a button element.</param>
		/// <param name="buttonText">The text to display on the trigger button. Use in conjunction with the showOn option set to "button" or "both".</param>
		/// <param name="calculateWeek">A function to calculate the week of the year for a given date. The default implementation uses the ISO 8601 definition: weeks start on a Monday; the first week of the year contains the first Thursday of the year.</param>
		/// <param name="changeMonth">Whether the month should be rendered as a dropdown instead of text.</param>
		/// <param name="changeYear">Whether the year should be rendered as a dropdown instead of text. Use the yearRange option to control which years are made available for selection.</param>
		/// <param name="closeText">The text to display for the close link. Use the showButtonPanel option to display this button.</param>
		/// <param name="constrainInput">When true, entry in the input field is constrained to those characters allowed by the current dateFormat option.</param>
		/// <param name="currentText">The text to display for the current day link. Use the showButtonPanel option to display this button.</param>
		/// <param name="dateFormat">The format for parsed and displayed dates. </param>
		/// <param name="dayNames">The list of long day names, starting from Sunday, for use as requested via the dateFormat option.</param>
		/// <param name="dayNamesMin">The list of minimised day names, starting from Sunday, for use as column headers within the datepicker.</param>
		/// <param name="dayNamesShort">The list of abbreviated day names, starting from Sunday, for use as requested via the dateFormat option.</param>
		/// <param name="defaultDate">Set the date to highlight on first opening if the field is blank. Specify either an actual date via a Date object or as a string in the current dateFormat, or a number of days from today (e.g. +7) or a string of values and periods ('y' for years, 'm' for months, 'w' for weeks, 'd' for days, e.g. '+1m +7d'), or null for today.</param>
		/// <param name="duration">Control the speed at which the datepicker appears, it may be a time in milliseconds or a string representing one of the three predefined speeds ("slow", "normal", "fast").</param>
		/// <param name="firstDay">Set the first day of the week: Sunday is 0, Monday is 1, etc.</param>
		/// <param name="gotoCurrent">When true, the current day link moves to the currently selected date instead of today.</param>
		/// <param name="hideIfNoPrevNext">Normally the previous and next links are disabled when not applicable (see the minDate and maxDate options). You can hide them altogether by setting this attribute to true.</param>
		/// <param name="isRTL">Whether the current language is drawn from right to left.</param>
		/// <param name="maxDate">The maximum selectable date. When set to null, there is no maximum.</param>
		/// <param name="minDate">The minimum selectable date. When set to null, there is no minimum.</param>
		/// <param name="monthNames">The list of full month names, for use as requested via the dateFormat option.</param>
		/// <param name="monthNamesShort">The list of abbreviated month names, as used in the month header on each datepicker and as requested via the dateFormat option.</param>
		/// <param name="navigationAsDateFormat">Whether the prevText and nextText options should be parsed as dates by the [[UI/Datepicker/formatDate|formatDate]] function, allowing them to display the target month names for example.</param>
		/// <param name="nextText">The text to display for the next month link. With the standard ThemeRoller styling, this value is replaced by an icon.</param>
		/// <param name="numberOfMonths">The number of months to show at once.</param>
		/// <param name="prevText">The text to display for the previous month link. With the standard ThemeRoller styling, this value is replaced by an icon.</param>
		/// <param name="selectOtherMonths">Whether days in other months shown before or after the current month are selectable. This only applies if the showOtherMonths option is set to true.</param>
		/// <param name="shortYearCutoff">The cutoff year for determining the century for a date (used in conjunction with [[UI/Datepicker#option-dateFormat|dateFormat]] 'y'). Any dates entered with a year value less than or equal to the cutoff year are considered to be in the current century, while those greater than it are deemed to be in the previous century.</param>
		/// <param name="showAnim">The name of the animation used to show and hide the datepicker. Use "show" (the default), "slideDown", "fadeIn", any of the jQuery UI effects. Set to an empty string to disable animation.</param>
		/// <param name="showButtonPanel">Whether to show the button panel.</param>
		/// <param name="showCurrentAtPos">When displaying multiple months via the numberOfMonths option, the showCurrentAtPos option defines which position to display the current month in.</param>
		/// <param name="showMonthAfterYear">Whether to show the month after the year in the header.</param>
		/// <param name="showOn">When the datepicker should appear. The datepicker can appear when the field receives focus ("focus"), when a button is clicked ("button"), or when either event occurs ("both").</param>
		/// <param name="showOptions">If using one of the jQuery UI effects for the showAnim option, you can provide additional settings for that animation via this option.</param>
		/// <param name="showOtherMonths">Whether to display dates in other months (non-selectable) at the start or end of the current month. To make these days selectable use the selectOtherMonths option.</param>
		/// <param name="showWeek">When true, a column is added to show the week of the year. The calculateWeek option determines how the week of the year is calculated. You may also want to change the firstDay option.</param>
		/// <param name="stepMonths">Set how many months to move when clicking the previous/next links.</param>
		/// <param name="weekHeader">The text to display for the week of the year column heading. Use the showWeek option to display this column.</param>
		/// <param name="yearRange">The range of years displayed in the year drop-down: either relative to today's year ("-nn:+nn"), relative to the currently selected year ("c-nn:c+nn"), absolute ("nnnn:nnnn"), or combinations of these formats ("nnnn:-nn"). Note that this option only affects what appears in the drop-down, to restrict which dates may be selected use the minDate and/or maxDate options.</param>
		/// <param name="yearSuffix">Additional text to display after the year in the month headers.</param>
		/// <returns>DatepickerWidget</returns>
		public DatepickerWidget Datepicker(String elementId = "", String target = "", Boolean disabled = false,
			String altField = "",
			String altFormat = "",
			String appendText = "",
			Boolean autoSize = false,
			String buttonImage = "",
			Boolean buttonImageOnly = false,
			String buttonText = "...",
			String calculateWeek = null,
			Boolean changeMonth = false,
			Boolean changeYear = false,
			String closeText = "Done",
			Boolean constrainInput = true,
			String currentText = "Today",
			String dateFormat = "mm/dd/yy",
			String[] dayNames = null,
			String[] dayNamesMin = null,
			String[] dayNamesShort = null,
			dynamic defaultDate = null,
			String duration = "normal",
			int firstDay = 0,
			Boolean gotoCurrent = false,
			Boolean hideIfNoPrevNext = false,
			Boolean isRTL = false,
			dynamic maxDate = null,
			dynamic minDate = null,
			String[] monthNames = null,
			String[] monthNamesShort = null,
			Boolean navigationAsDateFormat = false,
			String nextText = "Next",
			int numberOfMonths = 1,
			String prevText = "Prev",
			Boolean selectOtherMonths = false,
			dynamic shortYearCutoff = null,
			String showAnim = "show",
			Boolean showButtonPanel = false,
			int showCurrentAtPos = 0,
			Boolean showMonthAfterYear = false,
			String showOn = "focus",
			ShowOptions showOptions = null,
			Boolean showOtherMonths = false,
			Boolean showWeek = false,
			int stepMonths = 1,
			String weekHeader = "Wk",
			String yearRange = "c-10:c+10",
			String yearSuffix = ""			
			) {
			var widget = new DatepickerWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled,
				altField,
				altFormat,
				appendText,
				autoSize,
				buttonImage,
				buttonImageOnly,
				buttonText,
				calculateWeek,
				changeMonth,
				changeYear,
				closeText,
				constrainInput,
				currentText,
				dateFormat,
				dayNames,
				dayNamesMin,
				dayNamesShort,
				defaultDate,
				duration,
				firstDay,
				gotoCurrent,
				hideIfNoPrevNext,
				isRTL,
				maxDate,
				minDate,
				monthNames,
				monthNamesShort,
				navigationAsDateFormat,
				nextText,
				numberOfMonths,
				prevText,
				selectOtherMonths,
				shortYearCutoff,
				showAnim,
				showButtonPanel,
				showCurrentAtPos,
				showMonthAfterYear,
				showOn,
				showOptions,
				showOtherMonths,
				showWeek,
				stepMonths,
				weekHeader,
				yearRange,
				yearSuffix
			);

			return widget;
		}

	}

	public class DatepickerWidget : JuiceWidget<DatepickerWidget>, IDisposable {

		public DatepickerWidget(HtmlHelper helper) : base(helper, "datepicker") { }

		public DatepickerWidget Options(Boolean disabled = false, 
			String altField = "",
			String altFormat = "",
			String appendText = "",
			Boolean autoSize = false,
			String buttonImage = "",
			Boolean buttonImageOnly = false,
			String buttonText = "...",
			String calculateWeek = null,
			Boolean changeMonth = false,
			Boolean changeYear = false,
			String closeText = "Done",
			Boolean constrainInput = true,
			String currentText = "Today",
			String dateFormat = "mm/dd/yy",
			String[] dayNames = null,
			String[] dayNamesMin = null,
			String[] dayNamesShort = null,
			dynamic defaultDate = null,
			String duration = "normal",
			int firstDay = 0,
			Boolean gotoCurrent = false,
			Boolean hideIfNoPrevNext = false,
			Boolean isRTL = false,
			dynamic maxDate = null,
			dynamic minDate = null,
			String[] monthNames = null,
			String[] monthNamesShort = null,
			Boolean navigationAsDateFormat = false,
			String nextText = "Next",
			int numberOfMonths = 1,
			String prevText = "Prev",
			Boolean selectOtherMonths = false,
			dynamic shortYearCutoff = null,
			String showAnim = "show",
			Boolean showButtonPanel = false,
			int showCurrentAtPos = 0,
			Boolean showMonthAfterYear = false,
			String showOn = "focus",
			ShowOptions showOptions = null,
			Boolean showOtherMonths = false,
			Boolean showWeek = false,
			int stepMonths = 1,
			String weekHeader = "Wk",
			String yearRange = "c-10:c+10",
			String yearSuffix = ""
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => altField),
				JuiceHelpers.GetMemberInfo(() => altFormat),
				JuiceHelpers.GetMemberInfo(() => appendText),
				JuiceHelpers.GetMemberInfo(() => autoSize),
				JuiceHelpers.GetMemberInfo(() => buttonImage),
				JuiceHelpers.GetMemberInfo(() => buttonImageOnly),
				JuiceHelpers.GetMemberInfo(() => buttonText),
				JuiceHelpers.GetMemberInfo(() => calculateWeek),
				JuiceHelpers.GetMemberInfo(() => changeMonth),
				JuiceHelpers.GetMemberInfo(() => changeYear),
				JuiceHelpers.GetMemberInfo(() => closeText),
				JuiceHelpers.GetMemberInfo(() => constrainInput),
				JuiceHelpers.GetMemberInfo(() => currentText),
				JuiceHelpers.GetMemberInfo(() => dateFormat),
				JuiceHelpers.GetMemberInfo(() => dayNames),
				JuiceHelpers.GetMemberInfo(() => dayNamesMin),
				JuiceHelpers.GetMemberInfo(() => dayNamesShort),
				JuiceHelpers.GetMemberInfo(() => defaultDate),
				JuiceHelpers.GetMemberInfo(() => duration),
				JuiceHelpers.GetMemberInfo(() => firstDay),
				JuiceHelpers.GetMemberInfo(() => gotoCurrent),
				JuiceHelpers.GetMemberInfo(() => hideIfNoPrevNext),
				JuiceHelpers.GetMemberInfo(() => isRTL),
				JuiceHelpers.GetMemberInfo(() => maxDate),
				JuiceHelpers.GetMemberInfo(() => minDate),
				JuiceHelpers.GetMemberInfo(() => monthNames),
				JuiceHelpers.GetMemberInfo(() => monthNamesShort),
				JuiceHelpers.GetMemberInfo(() => navigationAsDateFormat),
				JuiceHelpers.GetMemberInfo(() => nextText),
				JuiceHelpers.GetMemberInfo(() => numberOfMonths),
				JuiceHelpers.GetMemberInfo(() => prevText),
				JuiceHelpers.GetMemberInfo(() => selectOtherMonths),
				JuiceHelpers.GetMemberInfo(() => shortYearCutoff),
				JuiceHelpers.GetMemberInfo(() => showAnim),
				JuiceHelpers.GetMemberInfo(() => showButtonPanel),
				JuiceHelpers.GetMemberInfo(() => showCurrentAtPos),
				JuiceHelpers.GetMemberInfo(() => showMonthAfterYear),
				JuiceHelpers.GetMemberInfo(() => showOn),
				JuiceHelpers.GetMemberInfo(() => showOptions),
				JuiceHelpers.GetMemberInfo(() => showOtherMonths),
				JuiceHelpers.GetMemberInfo(() => showWeek),
				JuiceHelpers.GetMemberInfo(() => stepMonths),
				JuiceHelpers.GetMemberInfo(() => weekHeader),
				JuiceHelpers.GetMemberInfo(() => yearRange),
				JuiceHelpers.GetMemberInfo(() => yearSuffix)
			);

			return this;
		}

	}
}
