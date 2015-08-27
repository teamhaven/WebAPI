using System;

namespace TeamHaven.WebApi.Models
{
	public class ServerTimeZone
	{
		/// <summary>
		/// TimeZone code
		/// </summary>
		public string TimeZone { get; set; }

		/// <summary>
		/// TimeZone description
		/// </summary>
		public string Description { get; set; }
	}
}
