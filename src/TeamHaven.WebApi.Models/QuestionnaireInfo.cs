using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class QuestionnaireInfo
	{
		public int QuestionnaireID { get; set; }
		public int Version { get; set; }
		public int? OriginalID { get; set; }
		public DateTimeOffset DateLastModified { get; set; }
		public QuestionnaireStatus Status { get; set; }
	}
}