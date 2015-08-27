using System;

namespace TeamHaven.WebApi.Models
{
	public class AccountNames
	{
		/// <summary>
		/// The Account's full name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A short, DNS-friendly name used to create the Account's Dedicated
		/// Domain Name (eg: shortname.teamhaven.com).
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// A domain name which has been CNAME'd to point to the Account's
		/// Dedicated Domain Name.
		/// </summary>
		public string CustomDomain { get; set; }
	}
}
