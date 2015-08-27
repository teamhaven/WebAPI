using System;

namespace TeamHaven.WebApi.Models
{
	public class Position
	{
		/// <summary>
		/// The latitude and longitude of the User, if known and if available to you.
		/// (Our agreement with Google maps prevents us from making LatLng information acquired by Geocoding available to you).
		/// </summary>
		public LatLng Coordinates { get; set; }

		/// <summary>
		/// If TRUE then we believe the Lat/Lng coordinates are accurate
		/// </summary>
		public bool? Accurate { get; set; }

		/// <summary>
		/// Where we got the coordinates from
		/// </summary>
		public PositionSource? Source { get; set; }

		/// <summary>
		/// If TRUE then the source failed to find a position
		/// (Maybe an address that couldn't be geocoded, or a GPS receiver that couldn't get a signal, etc)
		/// </summary>
		public bool? Failed { get; set; }
	}
}
