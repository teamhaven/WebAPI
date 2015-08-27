using System;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// This class represents the travel time and distance required
	/// for the leg of a journey between two locations.
	/// </summary>
	public class JourneyLeg
	{
		/// <summary>
		/// How long the journey will take (in minutes)
		/// </summary>
		public int? Time { get; set; }

		/// <summary>
		/// The journey distance (in miles)
		/// </summary>
		public double? Distance { get; set; }
	}
}
