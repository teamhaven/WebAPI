using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Integration Events are raised when key TeamHaven entities are updated. They are
	/// used to enable third party integration.
	/// </summary>
	public class IntegrationEvent
	{
		/// <summary>
		/// The object that was updated.
		/// </summary>
		public ObjectIdentifier Object { get; set; }

		/// <summary>
		/// The object's parent.
		/// Typically this will either be an Account or a Project.
		/// </summary>
		public ObjectIdentifier Parent { get; set; }

		/// <summary>
		/// The identity of the user who updated the object.
		/// </summary>
		public PartialIdentity User { get; set; }

		/// <summary>
		/// The type of update that occurred.
		/// </summary>
		public IntegrationEventType EventType { get; set; }

		/// <summary>
		/// UTC timestamp for when the update occurred
		/// </summary>
		public DateTimeOffset Timestamp { get; set; }
	}
}
