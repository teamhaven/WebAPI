using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class CallDiaryEntry
	{
		public int CallID { get; set; }
		public DateTime PlannedStart { get; set; }
		public int? PlannedDuration { get; set; }
		public int? PlannedTravelTime { get; set; }
		public double? PlannedTravelDistance { get; set; }
		public int? PlannedHomeTravelTime { get; set; }
		public double? PlannedHomeTravelDistance { get; set; }
	}
}
