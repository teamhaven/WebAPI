using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Hierarchy
	{
		public int? HierarchyID { get; set; }
		public int? ProjectID { get; set; }
		public int? ItemListID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<HierarchyLevel> Levels { get; set; }
	}
}
