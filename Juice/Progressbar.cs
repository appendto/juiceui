using System.Web.UI;
using Juice.Framework;

namespace Juice {
	public class ProgressBar : JuiceScriptControl {

		#region Widget Options

		/// <summary>
		/// The value of the progressbar.
		/// Reference: http://jqueryui.com/demos/progressbar/#value
		/// </summary>
		[WidgetOption("value", 0)]
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
