using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamHaven.WebApi.Models
{
	public class ErrorResponse
	{
		public string Message { get; set; }
		public List<string> Errors { get; set; }
		public string StackTrace { get; set; }
	}
}
