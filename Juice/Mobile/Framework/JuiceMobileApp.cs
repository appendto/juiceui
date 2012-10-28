using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;

using Juice.Framework;

namespace Juice.Mobile.Framework {
	public static class JuiceMobileApp {

		public static void Start() {

			ScriptManager.ScriptResourceMapping.AddDefinition("jquery-mobile",
				new ScriptResourceDefinition {
					Path = "~/Scripts/jquery.mobile-1.2.0.min.js",
					DebugPath = "~/Scripts/jquery.mobile-1.2.0.js",
					CdnPath = "http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.js",
					CdnDebugPath = "http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.js",
					CdnSupportsSecureConnection = false
				}
			);

			CssManager.CssResourceMapping.AddDefinition("jquery-mobile", new CssResourceDefinition {
				Path = "~/Content/jquery.mobile-1.2.0.min.css",
				DebugPath = "~/Content/jquery.mobile-1.2.0.css",
				CdnPath = "http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.css",
				CdnDebugPath = "http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.css"
			});

		}
	}
}
