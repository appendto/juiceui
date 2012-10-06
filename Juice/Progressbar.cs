using System.ComponentModel;
using System.Web.UI;
using Juice.Framework;

namespace Juice {
	public class ProgressBar : JuiceScriptControl {

		#region Widget Options

		/// <summary>
		/// The value of the progressbar.
		/// Reference: http://api.jqueryui.com/progressbar/#option-value
		/// </summary>
		[WidgetOption("value", 0)]
		[Category("Data")]
		[DefaultValue(0)]
		[Description("The value of the progressbar.")]
		public int Value { get; set; }

		#endregion

		public ProgressBar() : base("progressbar") { }

		protected override HtmlTextWriterTag TagKey {
			get {
				return HtmlTextWriterTag.Div;
			}
		}
	}
}
