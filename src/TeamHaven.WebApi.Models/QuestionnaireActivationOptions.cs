using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamHaven.WebApi.Models
{
	public class QuestionnaireActivationOptions
	{
		public int? QuestionnaireID { get; set; }
		public bool? UpdatePastBeingPlanned { get; set; }
		public bool? UpdateCurrentBeingPlanned { get; set; }
		public bool? UpdateFutureBeingPlanned { get; set; }
		public bool? UpdatePastActive { get; set; }
		public bool? UpdateCurrentActive { get; set; }
		public bool? UpdateFutureActive { get; set; }
	}
}
