using System;

namespace TeamHaven.WebApi.Models
{
	public enum ObjectType
	{
		Questionnaire = 1,
		Form = 2,
		Question = 3,
		Choice = 4,
		Item = 5,
		Target = 6,
		User = 7,
		Program = 8,
		Project = 9,
		ProjectTarget = 10,
		Account = 11,
		Call = 12,
		ProjectItem = 13,
		Answer = 14,
		ItemList = 15,
		ProjectTargetItem = 16,
		ScoreRule = 17,
		Score = 18,
	}

	public enum AuditAction
	{
		ImportCall = 1,
		UnplanCall = 2,
		PlanCall = 3,
		DeleteCall = 4,
		WithdrawCall = 5,
		SaveCall = 6,
		ReassignCall = 7,
		ResetCall = 8,
		ActivateCall = 9,
		DeactivateCall = 10,
		SaveAnswers = 11,
		CheckQuestionnaire = 12,
		ActivateQuestionnaire = 13,
		SaveQuestionnaire = 14,
		DeleteQuestionnaire = 15,
		SaveProjectTarget = 16,
		DeleteProjectTarget = 17,
		SetTargetPosition = 18,
		ImportProjectTarget = 19
	}

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
