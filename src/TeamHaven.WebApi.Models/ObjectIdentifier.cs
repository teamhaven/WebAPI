using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Unique identity for a TeamHaven object
	/// </summary>
	public class ObjectIdentifier
	{
		/// <summary>
		/// The type of TeamHaven object being identified
		/// </summary>
		public ObjectType ObjectType { get; set; }

		/// <summary>
		/// The object's database ID.
		/// </summary>
		public int ObjectID { get; set; }
	}
}
