
namespace Juice {
	public static class JuiceOptions {
		public static string CssPath { get; set; }
		public static string CssDebugPath { get; set; }
		public static string CssCdnPath { get; set; }
		public static string CssCdnDebugPath { get; set; }

		static JuiceOptions() {
			CssPath = "~/Content/themes/base/minified/jquery.ui.all.min.css";
			CssDebugPath = "~/Content/themes/base/jquery.ui.all.css";
			CssCdnPath = "//ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/themes/ui-lightness/jquery-ui.css";
			CssCdnDebugPath = "//ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/themes/ui-lightness/jquery-ui.css";
		}
	}
}