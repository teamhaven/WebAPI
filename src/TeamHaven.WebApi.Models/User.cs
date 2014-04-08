using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class User
	{
		public int UserID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string DisplayName { get; set; }
		public string GravatarHash { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public Dictionary<string,string> Attributes { get; set; }
		public List<AttributeDefinition> Schema { get; set; }
		public bool? Deleted { get; set; }
		public LatLng Position { get; set; }
		public double? Distance { get; set; }
	}
}
