using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Juice.Framework {

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class PropertyLinkAttribute : Attribute {

		private Guid _typeId;

		public PropertyLinkAttribute() {
			this._typeId = Guid.NewGuid();
		}

		public PropertyLinkAttribute(String propertyName, Type targetType) : this() {
			PropertyName = propertyName;
			TargetType = targetType;
		}

		public String PropertyName { get; set; }
		public Type TargetType { get; set; }

		// we need to override this because of the move pre-release to use *Descriptor classes instead of *Info.
		// *Descriptor classes filter out multiple attributes.
		public override object TypeId { get { return (object)this._typeId; } }
	}
}
