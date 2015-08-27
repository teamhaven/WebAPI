using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public class VacancySummary
	{
		public int Total { get; set; }
		public int Assigned { get; set; }
		public int Unassigned { get; set; }
	}
}
