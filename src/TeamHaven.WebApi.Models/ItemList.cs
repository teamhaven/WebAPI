using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class ItemList
	{
		/// <summary>
		/// The Item List's unique ID
		/// </summary>
		public int? ItemListID { get; set; }

		/// <summary>
		/// The Item List's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Item List's version number
		/// </summary>
		public int? Version { get; set; }

		/// <summary>
		/// The Project Target Attribute ID which defines the categories that this
		/// Item List varies by, or NULL if not a variable Item List
		/// </summary>
		public int? VariesByAttributeID { get; set; }

		/// <summary>
		/// Indicates the Item Lists's current state
		/// </summary>
		public ItemListStatus Status { get; set; }
	}
}
