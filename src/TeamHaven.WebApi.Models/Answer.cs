using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Answer
	{
		/// <summary>
		/// The QuestionID this is an answer for.
		/// </summary>
		public int QuestionID { get; set; }

		/// <summary>
		/// The ItemID this is an answer for, if question was asked on a Grid Form.
		/// </summary>
		public int? ItemID { get; set; }

		/// <summary>
		/// The answer value for Text questions.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// The GUID of the Picture for Picture answers. Use /api/account/:accountid/pictures/:guid to retrieve.
		/// </summary>
		public Guid? Picture { get; set; }

		/// <summary>
		/// The GUID of the Signature for Signature questions. Use /api/account/:accountid/signatures/:guid to retrieve.
		/// </summary>
		public Guid? Signature { get; set; }

		/// <summary>
		/// The answer value for Numeric questions.
		/// </summary>
		public Decimal? Number { get; set; }

		/// <summary>
		/// The answer value for ID questions.
		/// </summary>
		public int? ID { get; set; }

		/// <summary>
		/// A list of the ChoiceIDs selected for Single or Multiple Choice questions. For Single Choice
		/// questions, there will only ever be one ChoiceID in the list.
		/// </summary>
		public List<int> Choices { get; set; }

		/// <summary>
		/// The answer value for Yes/No questions.
		/// </summary>
		public bool? YesNo { get; set; }

		/// <summary>
		/// The answer value for Date, Time and Date/Time questions. For Date and Time questions, ignore the Time / Date portion respectively.
		/// </summary>
		public DateTime? DateTime { get; set; }
	}
}
