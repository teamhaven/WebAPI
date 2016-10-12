using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Item
	{
		public int ItemID { get; set; }
		public string Caption { get; set; }
		public Dictionary<string, string> Attributes { get; set; }
		public List<AttributeDefinition> Schema { get; set; }
		public bool? Deleted { get; set; }
	}
}
