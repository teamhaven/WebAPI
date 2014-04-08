using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class DocumentPermissions
	{
		public bool? ForManagers { get; set; }
		public bool? ForCoordinators { get; set; }
		public bool? ForCollectors { get; set; }
		public bool? ForClients { get; set; }
	}
}
