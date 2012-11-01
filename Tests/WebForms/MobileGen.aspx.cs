using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using Juice;
using Juice.Framework;

namespace WebForms {

	public partial class MobileGen : System.Web.UI.Page {

		private class Option {
			public WidgetOptionAttribute WidgetOption { get; set; }
			public PropertyDescriptor Property { get; set; }
		}

		protected override void OnLoad(EventArgs e) {

			String setOptionFormat = "\t\t\t\tJuiceHelpers.GetMemberInfo(() => {0})";
			String paramdocFormat = "\t\t/// <param name=\"{0}\">{1}</param>";
			String optionsMapFormat = "\t\t\t\t{{ \"{0}\", \"{1}\" }}";
			String paramFormat = "{0} {1} = {2}";

			List<String> widgets = new List<string>(){
				"Anchor",
				"Button",
				"Checkbox",
				"Collapsible",
				"CollapsibleSet",
				"Content",
				"ControlGroup",
				"Dialog",
				"FieldContainer",
				"FlipToggle",
				"Footer",
				"Header",
				"Listview",
				"Navbar",
				"Page",
				"Popup",
				"PopupAnchor",
				"RadioButton",
				"Select",
				"Slider",
				"Textbox"
			};

			foreach(var widgetName in widgets) {

				List<String> setOptionList = new List<string>();
				List<String> paramdocList = new List<string>();
				List<String> optionMapList = new List<string>();
				List<String> paramShortList = new List<string>();
				List<String> paramList = new List<String>();

				//String widgetName = "Button";
				String typeFormat = "Juice.Mobile.{0}, JuiceUI";
				Type widgetType = Type.GetType(String.Format(typeFormat, widgetName), false, true);
				String classTemplate = "";
				TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

				List<Option> widgetOptions =
					(from property in TypeDescriptor.GetProperties(widgetType).OfType<PropertyDescriptor>()
					 let attribute = property.Attributes.OfType<WidgetOptionAttribute>().SingleOrDefault()
					 let docAttribute = property.Attributes.OfType<WidgetDocumentAttribute>().SingleOrDefault()
					 let hideAttribute = property.Attributes.OfType<EditorBrowsableAttribute>().SingleOrDefault()
					 where (attribute != null || docAttribute != null) && (hideAttribute == null || hideAttribute.State != EditorBrowsableState.Never)
					 select new Option() {
						 Property = property,
						 WidgetOption = attribute
					 }).ToList();

				foreach(var o in widgetOptions) {

					var descAttr = o.Property.Attributes.OfType<DescriptionAttribute>().SingleOrDefault();
					String optionName = o.WidgetOption.Name;
					String[] parts = optionName.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
					String paramName = parts[0];

					for(var i = 1; i < parts.Length; i++) {
						paramName += textInfo.ToTitleCase(parts[i]);
					}

					if(descAttr != null) {
						paramdocList.Add(String.Format(paramdocFormat, paramName, descAttr.Description));
					}
					optionMapList.Add(String.Format(optionsMapFormat, paramName, optionName));
					setOptionList.Add(String.Format(setOptionFormat, paramName));
					paramShortList.Add(paramName);

					Type type = o.Property.PropertyType;
					object def = o.WidgetOption.DefaultValue;
					String defaultValue = def == null ? "null" : def.ToString();
					String typeName = type.Name;

					if((type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))) {
						Type[] args = type.GetGenericArguments();
						if(args.Length > 0) {
							typeName = args[0].Name + "?";
						}
					}

					if(type == typeof(bool) || type == typeof(Boolean)) {
						defaultValue = defaultValue.ToLower();
					}

					if(type == typeof(string) || type == typeof(String)) {
						defaultValue = "\"" + defaultValue + "\"";
					}

					paramList.Add(String.Format(paramFormat, typeName, paramName, String.IsNullOrEmpty(defaultValue) ? "\"\"" : defaultValue));
				}

				using(var sr = new StreamReader(Server.MapPath("MobileMvcTemplate.txt"))) {
					classTemplate = sr.ReadToEnd();
				}

				String setOptions = String.Join(",\n", setOptionList.ToArray());
				String paramdocs = String.Join(",\n", paramdocList.ToArray());
				String optionMap = String.Join(",\n", optionMapList.ToArray());
				String paramsShort = String.Join(", ", paramShortList.ToArray());
				String @params = String.Join(", ", paramList.ToArray());

				DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/") + "/../output");

				String result = classTemplate
					.Replace("{typeName}", widgetName)
					.Replace("{setOptions}", setOptions)
					.Replace("{paramdocs}", paramdocs)
					.Replace("{optionMap}", optionMap)
					.Replace("{paramsShort}", paramsShort)
					.Replace("{parameters}", @params);

				using(var sw = new StreamWriter(Path.Combine(dir.FullName, widgetName + ".cs"))) {
					sw.Write(result);
				}

			}
		}
		
	}
}