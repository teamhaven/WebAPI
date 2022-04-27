using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class VacantProject
	{
		public int ProjectID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<VacantTarget> Targets { get; set; }
		public PayrollMode PayrollMode { get; set; }
		public float? LabourRate { get; set; }
	}
}
