using System;

namespace TeamHaven.WebApi.Models
{
	public enum LogLevel
	{
		Emergency = 0,
		Alert = 1,
		Critical = 2,
		Error = 3,
		Warning = 4,
		Notice = 5,
		Info = 6,
		Debug = 7
	}

	public class LogSummary
	{
		public string Ticket { get; set; }
		public int UserID { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int WorstLevel { get; set; }
	}

	public class LogEntry
	{
		public DateTime Date { get; set; }
		public int? UserID { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public string Message { get; set; }
		public string Page { get; set; }
		public string Parameters { get; set; }
		public string UserAgent { get; set; }
		public string Referrer { get; set; }
		public int Level { get; set; }
	}
}
