using System;

namespace TeamHaven.WebApi.Models
{
	public class AccountSettings
	{
		/// <summary>
		/// The ISO 3166-1 alpha-2 country code of the country to be used when geocoding
		/// the position of users and targets which do not have a country as part of their address.
		/// </summary>
		public string DefaultCountry { get; set; }

		/// <summary>
		/// If TRUE then Collectors can change their own password.
		/// </summary>
		public bool? CollectorsCanChangePasswords { get; set; }

		/// <summary>
		/// If TRUE then Clients can change their own password.
		/// </summary>
		public bool? ClientsCanChangePasswords { get; set; }

		/// <summary>
		/// If TRUE then Questionnaire Design Roles are enabled.
		/// </summary>
		public bool? DesignRoles { get; set; }

		/// <summary>
		/// If TRUE then TeamHaven White Label is enabled.
		/// </summary>
		public bool? WhiteLabel { get; set; }

		/// <summary>
		/// The UserID of the Primary Account Holder. This is the only user
		/// able to change account settings.
		/// </summary>
		public int? PrimaryAccountHolderUserID { get; set; }
	}
}
