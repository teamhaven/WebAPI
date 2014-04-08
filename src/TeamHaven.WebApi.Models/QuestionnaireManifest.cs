using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// The Questionnaire Manifest is a simple table of contents for all the essential parts of a Questionnaire,
	/// but lacking the structure and layout information contained in a Questionnaire Design.
	/// </summary>
	public class QuestionnaireManifest
	{
		/// <summary>
		/// The Questionnaire's unique ID.
		/// </summary>
		public int QuestionnaireID { get; set; }

		/// <summary>
		/// A list of all the Questions in all of the Forms in the Questionnaire.
		/// </summary>
		public List<QuestionnaireQuestion> Questions { get; set; }

		/// <summary>
		/// A list of all the Items in all of the Grid Forms and Item Lists in the Questionnaire.
		/// </summary>
		public List<QuestionnaireItem> Items { get; set; }
	}
}
