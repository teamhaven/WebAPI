using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Various methods for getting in touch with somebody
	/// </summary>
	public class ContactInfo
	{
		/// <summary>
		/// An email address.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// A telephone number.
		/// </summary>
		public string Telephone { get; set; }

		/// <summary>
		/// A URL. Be sure to include a protocol prefix.
		/// Eg: http://www.teamhaven.com, not www.teamhaven.com
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// A Twitter handle (do not include the @ sign)
		/// </summary>
		public string Twitter { get; set; }

		/// <summary>
		/// A Facebook username
		/// </summary>
		public string Facebook { get; set; }
	}
}
