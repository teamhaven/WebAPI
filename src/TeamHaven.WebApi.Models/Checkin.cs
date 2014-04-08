using System;

namespace TeamHaven.WebApi.Models
{
	public enum CheckinType
	{
		/// <summary>
		/// Collector has arrived.
		/// </summary>
		Arrival = 1,

		/// <summary>
		/// Collector has departed.
		/// </summary>
		Departure = 2,

		/// <summary>
		/// General status update.
		/// </summary>
		Update = 3
	}

	/// <summary>
	/// A Checkin is a status update message sent by a Collector.
	/// </summary>
	public class Checkin
	{
		/// <summary>
		/// The Checkin's unique ID. Not required when sending a checkin.
		/// </summary>
		public int? CheckinID { get; set; }

		/// <summary>
		/// The Call ID that this checkin relates to.
		/// </summary>
		public int? CallID { get; set; }

		/// <summary>
		/// The type of checkin.
		/// </summary>
		public CheckinType Type { get; set; }

		/// <summary>
		/// A timestamp to associate with the checkin. Must be in UTC.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// A location to assocoiate with the checkin. Optional.
		/// </summary>
		public LatLng LatLng { get; set; }

		/// <summary>
		/// A message to include with the checkin. Optional.
		/// </summary>
		public string Message { get; set; }
	}
}
