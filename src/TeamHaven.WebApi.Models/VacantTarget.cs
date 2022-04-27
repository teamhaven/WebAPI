using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class VacantTarget
	{
		public int TargetID { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public Dictionary<string, string> Attributes { get; set; }
		public double? Distance { get; set; }
		public List<VacantCall> Calls { get; set; }
	}
}
