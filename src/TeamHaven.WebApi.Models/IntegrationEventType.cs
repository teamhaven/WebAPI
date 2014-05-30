using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public enum IntegrationEventType
	{
		/// <summary>
		/// The object was created.
		/// </summary>
		Created = 1,

		/// <summary>
		/// An existing object was updated.
		/// </summary>
		Updated = 2,

		/// <summary>
		/// An existing object was deleted.
		/// </summary>
		Deleted = 3,

		/// <summary>
		/// The call's answers were created / updated.
		/// </summary>
		Answered = 4
	}
}
