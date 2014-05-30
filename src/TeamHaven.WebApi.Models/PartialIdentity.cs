using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Basic information about a user's identity
	/// </summary>
	public class PartialIdentity
	{
		public int UserID { get; set; }
		public int AccountID { get; set; }
	}
}
