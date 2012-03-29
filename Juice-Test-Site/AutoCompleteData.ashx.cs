using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Juice_Sample_Site {
	/// <summary>
	/// Summary description for Handler1
	/// </summary>
	public class AutoCompleteData : IHttpHandler {

		private List<String> _data = new List<String>{ "ActionScript",
			"AppleScript",
			"Asp",
			"BASIC",
			"C",
			"C++",
			"Clojure",
			"COBOL",
			"ColdFusion",
			"Erlang",
			"Fortran",
			"Groovy",
			"Haskell",
			"Java",
			"JavaScript",
			"Lisp",
			"Perl",
			"PHP",
			"Python",
			"Ruby",
			"Scala",
			"Scheme" };

		public void ProcessRequest(HttpContext context) {
			context.Response.ContentType = "text/plain";

			String term = context.Request.QueryString["term"] ?? String.Empty;
			JavaScriptSerializer js = new JavaScriptSerializer();

			term = term.ToLower();

			List<String> result = _data.Where(d => d.ToLower().Contains(term)).ToList();

			context.Response.Write(js.Serialize(result));
		}

		public bool IsReusable {
			get {
				return false;
			}
		}
	}
}