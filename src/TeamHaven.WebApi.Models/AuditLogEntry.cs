using System;

namespace TeamHaven.WebApi.Models
{
	public class AuditLogEntry
	{
		public AuditAction Action { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public int UserID { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public int Count { get; set; }
	}
}
