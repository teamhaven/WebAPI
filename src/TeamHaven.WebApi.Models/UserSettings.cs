using System;

namespace TeamHaven.WebApi.Models
{
	public class UserSettings
	{
		public string UserLanguage { get; set; }
		public string TimeZone { get; set; }
		public DistanceUnit DistanceUnit { get; set; }
		public ExportFormat? ExportFormat { get; set; }
		public bool? IsAdvancedUser { get; set; }
		public string HomePage { get; set; }
	}
}
