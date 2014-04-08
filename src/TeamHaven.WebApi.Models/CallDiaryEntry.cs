using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class CallDiaryEntry
	{
		public int CallID { get; set; }
		public DateTime PlannedStart { get; set; }
		public int? PlannedDuration { get; set; }
		public int? TravelTime { get; set; }
		public double? TravelDistance { get; set; }
	}
}
