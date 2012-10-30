﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.WebPages;


namespace Juice.Mvc {
	public class JuiceWidget<TWidget> where TWidget : JuiceWidget<TWidget>, IDisposable {

		protected HtmlHelper _helper = null;
		protected HtmlTextWriter _writer;
		protected Func<TWidget, HelperResult> _content = null;
		protected String _elementId = String.Empty;
		protected String _target = String.Empty;

		protected String _widgetName = String.Empty;
		private Boolean _disposing = false;

		private Dictionary<String, Member> _options = new Dictionary<String, Member>();

		private const string _script = "$(function(){{\n\t\t$(\"{0}\").{1}({2});\n}});";

		public JuiceWidget(HtmlHelper helper, String widgetName) {
			_helper = helper;
			_writer = helper.ViewContext.HttpContext.Request.Browser.CreateHtmlTextWriter(helper.ViewContext.Writer);
			_widgetName = widgetName;
		}

		internal virtual HtmlTextWriterTag Tag { get { return HtmlTextWriterTag.Div;  } }

		// primarily for button -> buttonset
		protected String WidgetName {
			get { return _widgetName; }
			set { _widgetName = value; }
		}

		internal void SetOptions(params Member[] options) {
			
			foreach(var member in options){
				if(_options.ContainsKey(member.Name)) {
					_options[member.Name] = member;
				}
				else {
					_options.Add(member.Name, member);
				}
			}
		}

		internal void SetCoreOptions(String elementId, String target) {
			
			// didn't specify an id or target selector? you'll take a silly id and like it, mister!
			if(String.IsNullOrEmpty(elementId) && String.IsNullOrEmpty(target)) {
				elementId = Guid.NewGuid().ToString();
			}
			
			_elementId = elementId;
			_target = target;

			return;
		}

		public TWidget Content(Func<TWidget, HelperResult> content) {
			this._content = content;

			return this as TWidget;
		}

		public void End() { }

		public virtual void Render() {

			// if they specify an elementId, they want us to render it for them.
			if(!String.IsNullOrEmpty(_elementId)) {
				RenderStart();

				if(_content != null) {

					HelperResult res = _content(this as TWidget);
					_writer.Write(res.ToHtmlString());
				}

				RenderEnd();
			}

			var target = !String.IsNullOrEmpty(_elementId) ? "#" + _elementId : _target;
			var json = new System.Web.Script.Serialization.JavaScriptSerializer();
			var options = _options
											.Where(o => o.Value.EqualsDefault == false)
											.ToDictionary(k => k.Key, k => k.Value.Value);

			_writer.Write("\n");
			_writer.RenderBeginTag(HtmlTextWriterTag.Script);
			_writer.Write(String.Format(_script, target, _widgetName, options.Keys.Count > 0 ? json.Serialize(options) : String.Empty));
			_writer.RenderEndTag();
			
		}

		public virtual void RenderStart() {
			_writer.AddAttribute("id", _elementId);
			_writer.RenderBeginTag(HtmlTextWriterTag.Div);
		}

		public virtual void RenderEnd() {
			_writer.RenderEndTag();
		}

		public override string ToString() {
			Render();
			return String.Empty;
		}

		public void Dispose() {

			if(!_disposing) {
				_disposing = true;

				_writer.Dispose();
			}

		}
	}
}
