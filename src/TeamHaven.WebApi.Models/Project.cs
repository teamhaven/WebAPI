using System;

namespace TeamHaven.WebApi.Models
{
	public enum CheckinMode
	{
		Off = 0,
		Required = 1
	}

	public class Project
	{
		public int ProjectID { get; set; }
		public string Name { get; set; }
		public CheckinMode CheckinMode { get; set; }
	}
}
