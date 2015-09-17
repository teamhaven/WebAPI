using System;

namespace TeamHaven.WebApi.Models
{
	public class WorkHistory
	{
		public int? ProjectID { get; set; }
		public string ProjectName { get; set; }
		public int? CompletedCalls { get; set; }
		public DateTime? FirstActivity { get; set; }
		public DateTime? LastActivity { get; set; }
	}
}
