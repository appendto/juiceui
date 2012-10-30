using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Open content in an interactive overlay.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the Dialog if set to true.</param>
		/// <param name="autoOpen">If set to true, the dialog will automatically open upon initialization. If false, the dialog will stay hidden until the open() method is called.</param>
		/// <param name="buttons">Specifies which buttons should be displayed on the dialog. The context of the callback is the dialog element; if you need access to the button, it is available as the target of the event object.</param>
		/// <param name="closeOnEscape">Specifies whether the dialog should close when it has focus and the user presses the esacpe (ESC) key.</param>
		/// <param name="closeText">Specifies the text for the close button. Note that the close text is visibly hidden when using a standard theme.</param>
		/// <param name="dialogClass">The specified class name(s) will be added to the dialog, for additional theming.</param>
		/// <param name="draggable">If set to true, the dialog will be draggable by the title bar. Requires the jQuery UI Draggable wiget to be included.</param>
		/// <param name="height">The height of the dialog.</param>
		/// <param name="hide">If and how to animate the hiding of the dialog.</param>
		/// <param name="maxHeight">The maximum height to which the dialog can be resized, in pixels.</param>
		/// <param name="maxWidth">The maximum width to which the dialog can be resized, in pixels.</param>
		/// <param name="minHeight">The minimum height to which the dialog can be resized, in pixels.</param>
		/// <param name="minWidth">The minimum width to which the dialog can be resized, in pixels.</param>
		/// <param name="modal">If set to true, the dialog will have modal behavior; other items on the page will be disabled, i.e., cannot be interacted with. Modal dialogs create an overlay below the dialog but above other page elements.</param>
		/// <param name="resizable">If set to true, the dialog will be resizable. Requires the jQuery UI Resizable widget to be included.</param>
		/// <param name="show">If and how to animate the showing of the dialog.</param>
		/// <param name="stack">Specifies whether the dialog will stack on top of other dialogs. This will cause the dialog to move to the front of other dialogs when it gains focus.</param>
		/// <param name="title">Specifies the title of the dialog. Any valid HTML may be set as the title. The title can also be specified by the title attribute on the dialog source element.</param>
		/// <param name="width">The width of the dialog, in pixels.</param>
		/// <param name="zIndex">The starting z-index for the dialog.</param>
		/// <returns>DialogWidget</returns>
		public DialogWidget Dialog(String elementId = "", String target = "", Boolean disabled = false,
			Boolean autoOpen = true,
			ButtonList buttons = null,
			Boolean closeOnEscape = true,
			String closeText = "close",
			String dialogClass = "",
			Boolean draggable = true,
			dynamic height = null,
			dynamic hide = null,
			int maxHeight = -1,
			int maxWidth = -1,
			int minHeight = 150,
			int minWidth = 150,
			Boolean modal = false,
			Boolean resizable = true,
			dynamic show = null,
			Boolean stack = true,
			String title = "",
			int width = 300,
			int zIndex = 1000			
			) {
			var widget = new DialogWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(disabled, 
				autoOpen,
				buttons,
				closeOnEscape,
				closeText,
				dialogClass,
				draggable,
				height,
				hide,
				maxHeight,
				maxWidth,
				minHeight,
				minWidth,
				modal,
				resizable,
				show,
				stack,
				title,
				width,
				zIndex				
			);

			return widget;
		}

	}

	public class DialogWidget : JuiceWidget<DialogWidget>, IDisposable {

		public DialogWidget(HtmlHelper helper) : base(helper, "dialog") { }

		public DialogWidget Options(Boolean disabled = false, 
			Boolean autoOpen = true,
			ButtonList buttons = null,
			Boolean closeOnEscape = true,
			String closeText = "close",
			String dialogClass = "",
			Boolean draggable = true,
			dynamic height = null,
			dynamic hide = null,
			int maxHeight = -1,
			int maxWidth = -1,
			int minHeight = 150,
			int minWidth = 150,
			Boolean modal = false,
			Boolean resizable = true,
			dynamic show = null,
			Boolean stack = true,
			String title = "",
			int width = 300,
			int zIndex = 1000
			) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => autoOpen),
				JuiceHelpers.GetMemberInfo(() => buttons),
				JuiceHelpers.GetMemberInfo(() => closeOnEscape),
				JuiceHelpers.GetMemberInfo(() => closeText),
				JuiceHelpers.GetMemberInfo(() => dialogClass),
				JuiceHelpers.GetMemberInfo(() => draggable),
				JuiceHelpers.GetMemberInfo(() => height),
				JuiceHelpers.GetMemberInfo(() => hide),
				JuiceHelpers.GetMemberInfo(() => maxHeight),
				JuiceHelpers.GetMemberInfo(() => maxWidth),
				JuiceHelpers.GetMemberInfo(() => minHeight),
				JuiceHelpers.GetMemberInfo(() => minWidth),
				JuiceHelpers.GetMemberInfo(() => modal),
				JuiceHelpers.GetMemberInfo(() => resizable),
				JuiceHelpers.GetMemberInfo(() => show),
				JuiceHelpers.GetMemberInfo(() => stack),
				JuiceHelpers.GetMemberInfo(() => title),
				JuiceHelpers.GetMemberInfo(() => width),
				JuiceHelpers.GetMemberInfo(() => zIndex)
			);

			return this;
		}

	}
}
