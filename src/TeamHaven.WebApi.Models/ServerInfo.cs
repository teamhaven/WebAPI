using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public class ServerInfo
	{
		/// <summary>
		/// TRUE if this server is dedicated to a specific account.
		/// An Authorization header containing using just Username and Password is acceptable on dedicated servers.
		/// </summary>
		public bool Dedicated { get; set; }

		/// <summary>
		/// The name of this server.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The display theme used by this server.
		/// </summary>
		public Theme Theme { get; set; }

		/// <summary>
		/// If TRUE, then this server is white-labelled, meaning it does
		/// not display any TeamHaven branding.
		/// </summary>
		public bool WhiteLabel { get; set; }

		/// <summary>
		/// The support contact information for this server.
		/// (Typically null for generic servers)
		/// </summary>
		public ContactInfo Support { get; set; }

		/// <summary>
		/// If available over HTTPS, this is the URL to use
		/// Eg: https://www.teamhaven.com:443
		/// </summary>
		public string HttpsUrl { get; set; }

		/// <summary>
		/// If available over HTTP, this is the URL to use
		/// Eg: http://www.teamhaven.com:80 
		/// </summary>
		public string HttpUrl { get; set; }
	}
}
