using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Juice.Mvc {

	public partial class JuiceHelpers {

		/// <summary>
		/// Autocomplete enables users to quickly find and select from a pre-populated list of values as they type, leveraging searching and filtering.
		/// </summary>
		/// <param name="elementId">Specifies the value the ID attribute of the rendered element. If specified, <paramref name="target"/> parameter is ignored.</param>
		/// <param name="target">Specifies a selector identifying the element the widget should be applied to.</param>
		/// <param name="disabled">Disables the AutoComplete if set to true.</param>
		/// <param name="appendTo">Which element the menu should be appended to. Override this when the autocomplete is inside a position: fixed element. Otherwise the popup menu would still scroll with the page.</param>
		/// <param name="autoFocus">If set to true the first item will automatically be focused when the menu is shown.</param>
		/// <param name="delay">The delay in milliseconds between when a keystroke occurs and when a search is performed. A zero-delay makes sense for local data (more responsive), but can produce a lot of load for remote data, while being less responsive.</param>
		/// <param name="minLength">The minimum number of characters a user must type before a search is performed. Zero is useful for local data with just a few items, but a higher value should be used when a single character search could match a few thousand items.</param>
		/// <param name="source">Defines the data to use, must be specified. Array or Dictionary is recommended.</param>
		/// <returns>AutoCompleteWidget</returns>
		public AutoCompleteWidget AutoComplete(String elementId = "", String target = "", String labelText = "Select:", Boolean disabled = false, String appendTo = "body", Boolean autoFocus = false, int delay = 300, int minLength = 1, dynamic source = null) {
			var widget = new AutoCompleteWidget(_helper);

			widget.SetCoreOptions(elementId, target);
			widget.Options(labelText, disabled, appendTo, autoFocus, delay, minLength, source);

			return widget;
		}

	}

	public class AutoCompleteWidget : JuiceWidget<AutoCompleteWidget>, IDisposable {

		public AutoCompleteWidget(HtmlHelper helper) : base(helper, "autocomplete") { }

		internal override HtmlTextWriterTag Tag {
			get {
				return HtmlTextWriterTag.Input;
			}
		}

		public String LabelText { get; set; }

		public AutoCompleteWidget Options(String labelText = "Select:", Boolean disabled = false, String appendTo = "body", Boolean autoFocus = false, int delay = 300, int minLength = 1, dynamic source = null) {

			LabelText = labelText;
			
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => disabled),
				JuiceHelpers.GetMemberInfo(() => appendTo), 
				JuiceHelpers.GetMemberInfo(() => autoFocus), 
				JuiceHelpers.GetMemberInfo(() => delay), 
				JuiceHelpers.GetMemberInfo(() => minLength), 
				JuiceHelpers.GetMemberInfo(() => source)
			);

			return this;
		}

		public override void RenderStart() {
			//<label for="autocomplete">Select a programming language: </label>
			//<input id="autocomplete">
			_writer.AddAttribute("for", _elementId);
			_writer.RenderBeginTag(HtmlTextWriterTag.Label);
			_writer.Write(LabelText);
			_writer.RenderEndTag();

			_writer.Write("<" + this.Tag);
			_writer.WriteAttribute("id", _elementId);
			_writer.Write("/>");
		}

		public override void RenderEnd() {
		}
	}
}
