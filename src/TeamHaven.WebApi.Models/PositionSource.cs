using System;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Indicates where we got a particular LatLng from
	/// </summary>
	public enum PositionSource
	{
		/// <summary>
		/// We don't know where we got the position from
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// The position was supplied in an import file or by a user dragging a pushpin
		/// </summary>
		Manual = 1,

		/// <summary>
		/// We got the position from a GPS device
		/// </summary>
		GPS = 2,

		/// <summary>
		/// We got the position by looking up an address
		/// </summary>
		Geocode = 3
	};
}
