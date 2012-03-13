using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile {
	public static class JuiceMobileApp {

		public static void Start() {

			ScriptManager.ScriptResourceMapping.AddDefinition("jquery-mobile",
					new ScriptResourceDefinition {
						Path = "~/Scripts/jquery.mobile-1.0.1.min.js",
						DebugPath = "~/Scripts/jquery.mobile-1.0.1.js",
						CdnPath = "http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.js",
						CdnDebugPath = "http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.js",
						CdnSupportsSecureConnection = true
					}
			);

			CssManager.CssResourceMapping.AddDefinition("jquery-mobile", new CssResourceDefinition {
				Path = "~/Content/jquery.mobile-1.0.1.min.css",
				DebugPath = "~/Content/jquery.mobile-1.0.1.css",
				CdnPath = "http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.min.css",
				CdnDebugPath = "http://code.jquery.com/mobile/1.0.1/jquery.mobile-1.0.1.css"
			});

		}
	}
}
