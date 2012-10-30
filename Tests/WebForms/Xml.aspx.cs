using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebForms {

	public partial class Xml : System.Web.UI.Page {
		protected override void OnLoad(EventArgs e) {

			String currentMvcHelper = "AutoComplete";
			const String helperPrefix = "M:Juice.Mvc.JuiceHelpers.";
			const String helperFormat = "//member[starts-with(@name, \"{0}{1}\")]";

			Type helperType = typeof(Juice.Mvc.JuiceHelpers);

			FileInfo xmlFile = new FileInfo(Server.MapPath("~/bin/juiceui.xml"));
			String xmlContent = String.Empty;
			XmlDocument xml = new XmlDocument();

			using(var sr = new StreamReader(xmlFile.FullName)) {
				xmlContent = sr.ReadToEnd();
			}

			xml.LoadXml(xmlContent);

			var helperNode = xml.SelectSingleNode(String.Format(helperFormat, helperPrefix, currentMvcHelper));
			var helperMethod = helperType.GetMethod(currentMvcHelper);
			var helperReturnType = helperMethod.ReturnType;
			var optionsMethod = helperReturnType.GetMethod("Options");
			var @params = optionsMethod.GetParameters();

			var testOutputFormat = "Name: {0}, Default: {1}, Description: {2}<br/>";

			foreach(var param in @params) {
				var name = param.Name;
				var defvalue = param.DefaultValue == null ? "null" : param.DefaultValue.ToString();
				var paramNode = helperNode.SelectSingleNode("param[@name=\"" + name + "\"]");

				if(paramNode == null) {
					continue;
				}

				var desc = paramNode.InnerText;

				_out.Text += String.Format(testOutputFormat, name, defvalue, desc);
			}
		}
	}
}