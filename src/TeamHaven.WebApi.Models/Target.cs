using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Target
	{
		public int TargetID { get; set; }
		public int? ProjectID { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public Dictionary<string,string> Attributes { get; set; }
		public List<AttributeDefinition> Schema { get; set; }
		public LatLng LatLng { get; set; }
	}
}