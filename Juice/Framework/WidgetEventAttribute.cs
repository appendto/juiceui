using System;

namespace Juice.Framework {

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Event, AllowMultiple = true)]
	public class WidgetEventAttribute : Attribute {

		private Guid _typeId;

		public WidgetEventAttribute(String name) {
			this.Name = name;
			this._typeId = Guid.NewGuid();
		}

		/// <summary>
		/// The jQuery UI name of the event.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// True, if the event can trigger an AutoPostBack. False, otherwise.
		/// </summary>
		public Boolean AutoPostBack { get; set; }

		/// <summary>
		/// True, if the event is the handler for the IPostbackDataChanged Implementation.
		/// </summary>
		public Boolean DataChangedHandler { get; set; }

		public override object TypeId { get { return (object)this._typeId; } }
	}
}