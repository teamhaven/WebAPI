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
	}
}
