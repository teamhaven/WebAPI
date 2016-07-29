using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class QuestionnaireSummary
	{
		public QuestionnaireInfo Active { get; set; }
		public QuestionnaireInfo Draft { get; set; }
	}
}
