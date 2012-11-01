using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.Mvc;

using Juice.Framework;

namespace Juice.Mvc {

	public static class HtmlHelpers {

		public static JuiceHelpers Juice(this HtmlHelper helper) {
			return new JuiceHelpers(helper);
		}

	}


	public class Member {
		public String Name { get; set; }
		public object Value { get; set; }
		public object DefaultValue { get; set; }

		public Boolean EqualsDefault {
			get {

				Boolean arraysEqual =
						Value != null
						&& Value.GetType().IsArray
						&& DefaultValue != null
						&& DefaultValue.GetType().IsArray
						&& ((IEnumerable<object>)Value).ItemsAreEqual((IEnumerable<object>)DefaultValue);

				Boolean result = !((Value == null && DefaultValue != null) || (Value != null && !Value.Equals(DefaultValue) && !arraysEqual));

				return result;
			}
		}
	}

	public partial class JuiceHelpers {

		protected HtmlHelper _helper;

		public JuiceHelpers(HtmlHelper helper) {
			_helper = helper;
		}

		public HtmlHelper Helper { get { return _helper; } }

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static MethodBase GetCallingMethod() {
			return new System.Diagnostics.StackFrame(2, false).GetMethod();
		}

		internal static List<String> GetParameters(MethodBase method) {
			return method.GetParameters().Select(p => p.Name).ToList();
		}

		internal static Member GetMemberInfo<T>(Expression<Func<T>> expr) {
			var body = ((MemberExpression)expr.Body);
			var method = GetCallingMethod();
			var parameter = method.GetParameters().Where(p => p.Name == body.Member.Name).FirstOrDefault();

			object defaultValue = parameter.DefaultValue;

			return new Member {
				Name = body.Member.Name,
				Value = ((FieldInfo)body.Member).GetValue(((ConstantExpression)body.Expression).Value),
				DefaultValue = defaultValue
			};
		}

	}

}
