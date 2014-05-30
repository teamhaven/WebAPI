using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// An enumeration of the different TeamHaven entity types.
	/// </summary>
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
}
