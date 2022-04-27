using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class VacantCall
	{
		public int CallID { get; set; }
		public DateTime EarliestDate { get; set; }
		public DateTime LatestDate { get; set; }
		public bool SelfAssigned { get; set; }
		public double? EstimatedPay { get; set; }
		public Dictionary<string, string> Attributes { get; set; }

		public bool FixedAppointment { get; set; }
		public DateTime? PlannedStart { get; set; }
		public int? PlannedDuration { get; set; }
	}
}
