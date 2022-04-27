using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class User
	{
		/// <summary>
		/// The User's unique ID
		/// </summary>
		public int? UserID { get; set; }

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
		/// The User's Role
		/// </summary>
		public Role? Role { get; set; }

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
		/// Information about the User's position, including Lat/Lng coordinates
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// How far away the user is from the point specified during a User Search.
		/// </summary>
		public double? Distance { get; set; }

		/// <summary>
		/// The User's rating, if any. Should be 1-5 or null if not rated.
		/// </summary>
		public int? Rating { get; set; }

		/// <summary>
		/// Which Projects the user can access, if their role is governed by a Project List.
		/// </summary>
		public List<int> ProjectList { get; set; }

		/// <summary>
		/// TRUE if the user is not a Collector but can be assigned to Calls.
		/// </summary>
		public bool? IsCollector { get; set; }

		/// <summary>
		/// TRUE if the user can not make any changes to TeamHaven.
		/// </summary>
		public bool? IsReadOnly { get; set; }

		/// <summary>
		/// TRUE if the user can access "advanced" functions
		/// </summary>
		public bool? IsAdvanced { get; set; }

		/// <summary>
		/// The Attribute Locks imposed on this User.
		/// </summary>
		public string AttributeLocks { get; set; }

		/// <summary>
		/// The maximum number of hours per day the user can work.
		/// If null then the Account's setting should be applied.
		/// </summary>
		public double? HoursPerDay { get; set; }
	}
}
