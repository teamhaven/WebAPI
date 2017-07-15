using System;

namespace TeamHaven.WebApi.Models
{
	public class VacantCall
	{
		public int CallID { get; set; }
		public DateTime EarliestDate { get; set; }
		public DateTime LatestDate { get; set; }
		public bool SelfAssigned { get; set; }
		public double? EstimatedPay { get; set; }
	}
}