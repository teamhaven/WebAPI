using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Item
	{
		/// <summary>
		/// The Item's unique identifier
		/// </summary>
		public int? ItemID { get; set; }

		/// <summary>
		/// The Item's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A dictionary of Attribute Values associated with the Item
		/// </summary>
		public Dictionary<string, string> Attributes { get; set; }

		/// <summary>
		/// If requested, the Attribute Schema of the Item List which contains this Item
		/// </summary>
		public List<AttributeDefinition> Schema { get; set; }

		/// <summary>
		/// If true, then this Item has been deleted from the Item List
		/// </summary>
		public bool? Deleted { get; set; }
	}
}
