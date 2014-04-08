using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class DocumentPermissions
	{
		/// <summary>
		/// Users in the Manager role can access this document.
		/// </summary>
		public bool? ForManagers { get; set; }

		/// <summary>
		/// Users in the Coordinator role can access this document.
		/// </summary>
		public bool? ForCoordinators { get; set; }

		/// <summary>
		/// Users in the Collector role can access this document.
		/// </summary>
		public bool? ForCollectors { get; set; }

		/// <summary>
		/// Users in the Client role can access this document.
		/// </summary>
		public bool? ForClients { get; set; }
	}
}
