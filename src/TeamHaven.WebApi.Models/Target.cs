using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// A TeamHaven Target. Typically this is a Store, Shop or other location to be visited.
	/// </summary>
	public class Target
	{
		/// <summary>
		/// The Target's unique ID
		/// </summary>
		public int? TargetID { get; set; }

		/// <summary>
		/// The ID of the Project that this Target belongs to.
		/// </summary>
		public int? ProjectID { get; set; }

		/// <summary>
		/// The Target's name. EG: "PC World", or "Asda #123"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Target's details. Typically this is the address in a human-readable format.
		/// </summary>
		public string Details { get; set; }

		/// <summary>
		/// A dictionary of attributes associated with the Target.
		/// </summary>
		public Dictionary<string,string> Attributes { get; set; }

		/// <summary>
		/// If requested, the Project's Target Attribute Schema.
		/// </summary>
		public List<AttributeDefinition> Schema { get; set; }

		/// <summary>
		/// The latitude and longitude of the Target, if known and if available to you.
		/// (Our agreement with Google maps prevents us from making LatLng information acquired by Geocoding available to you).
		/// </summary>
		[Obsolete()]
		public LatLng LatLng { get; set; }

		/// <summary>
		/// Information about the Target's position, including Lat/Lng coordinates
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// Indicates that the Target has been deleted.
		/// </summary>
		public bool? Deleted { get; set; }
	}
}