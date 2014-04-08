using System;

namespace TeamHaven.WebApi.Models
{
	public enum CheckinType
	{
		Arrival = 1,
		Departure = 2,
		Update = 3
	}

	public class Checkin
	{
		public int? CheckinID { get; set; }
		public int? CallID { get; set; }
		public CheckinType Type { get; set; }
		public DateTime? Date { get; set; }
		public LatLng LatLng { get; set; }
		public string Message { get; set; }
	}
}
