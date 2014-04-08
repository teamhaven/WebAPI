using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class User
	{
		/// <summary>
		/// The User's unique ID
		/// </summary>
		public int UserID { get; set; }

		/// <summary>
		/// The User's unique Username
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// The User's password (this will be removed in a later API version)
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// The User's display name / full name.
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		/// A hash for use in displaying Gravatars (http://gravatar.com)
		/// </summary>
		public string GravatarHash { get; set; }

		/// <summary>
		/// The Date and Time the user last logged in
		/// </summary>
		public DateTime? LastLoginDate { get; set; }

		/// <summary>
		/// A dictionary of attributes associated with the user.
		/// </summary>
		public Dictionary<string,string> Attributes { get; set; }

		/// <summary>
		/// If requested, the User's attribute schema.
		/// </summary>
		public List<AttributeDefinition> Schema { get; set; }

		/// <summary>
		/// If true, then the user has been deleted and can not log in or be assigned to calls.
		/// </summary>
		public bool? Deleted { get; set; }

		/// <summary>
		/// The latitude and longitude of the User, if known and if available to you.
		/// (Our agreement with Google maps prevents us from making LatLng information acquired by Geocoding available to you).
		/// </summary>
		public LatLng Position { get; set; }

		/// <summary>
		/// How far away the user is from the point specified during a User Search.
		/// </summary>
		public double? Distance { get; set; }
	}
}
