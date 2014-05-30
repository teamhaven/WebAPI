using System;

namespace TeamHaven.WebApi.Models
{
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
}
