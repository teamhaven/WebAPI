using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Questionnaire
	{
		/// <summary>
		/// The Questionnaire's unique ID.
		/// </summary>
		public int QuestionnaireID { get; set; }

		/// <summary>
		/// The Questionnaire's caption.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// An ordered list of the Forms in the Questionnaire.
		/// </summary>
		public List<QuestionnaireForm> Forms { get; set; }

		/// <summary>
		/// A dictionary of the Item Lists referenced by the Questionniare, indexed by ItemListID.
		/// </summary>
		public Dictionary<int, QuestionnaireItemList> ItemLists { get; set; }
	}

	public enum QuestionnaireFormType
	{
		Survey = 1,
		Grid = 2,
		AssetAudit = 4
	}

	public class QuestionnaireForm
	{
		public int FormID { get; set; }
		public string Caption { get; set; }
		public List<QuestionnaireQuestion> Questions { get; set; }
		public List<QuestionnaireItem> Items { get; set; }
		public QuestionnaireItemListRefererence ItemList { get; set; }
		public string EnableExpression { get; set; }
		public QuestionnaireFormType Type { get; set; }
	}

	public enum QuestionnaireQuestionType
	{
		Text = 1,
		Numeric = 2,
		SingleChoice = 3,
		MultipleChoice = 4,
		DateTime = 5,
		YesNo = 6,
		ID = 7,
		Date = 8,
		Time = 9,
		Picture = 10,
		Signature = 11
	}

	/// <summary>
	/// The design of a single Question in a Questionnaire
	/// </summary>
	public class QuestionnaireQuestion
	{
		/// <summary>
		/// The Question's unique ID.
		/// </summary>
		public int QuestionID { get; set; }

		/// <summary>
		/// The Question's Caption.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// The Question's Type
		/// </summary>
		public QuestionnaireQuestionType? Type { get; set; }

		/// <summary>
		/// Flag indicating whether the Question must be answered.
		/// </summary>
		public bool? Required { get; set; }

		/// <summary>
		/// Flag indicating whether the Question's Answer can not be modified.
		/// </summary>
		public bool? ReadOnly { get; set; }

		/// <summary>
		/// The TQL expression controlling whether this Question is enabled.
		/// </summary>
		public string EnableExpression { get; set; }

		// Numeric question properties
		/// <summary>
		/// The minimum acceptable value (for Numeric questions).
		/// </summary>
		public decimal? MinValue { get; set; }

		/// <summary>
		/// The maximum acceptable value (for Numeric questions).
		/// </summary>
		public decimal? MaxValue { get; set; }

		/// <summary>
		/// The required number of decimal places (for Numeric questions).
		/// </summary>
		public int? DecimalPlaces { get; set; }

		/// <summary>
		/// A prefix to display in front of Numeric answers.
		/// </summary>
		public string Prefix { get; set; }

		/// <summary>
		/// A suffix to display at the end of Numeric answers.
		/// </summary>
		public string Suffix { get; set; }

		// Text question properties
		/// <summary>
		/// The minimum acceptable answer length (for Text questions).
		/// </summary>
		public int? MinLength { get; set; }

		/// <summary>
		/// The maximum acceptable answer length (for Text questions).
		/// </summary>
		public int? MaxLength { get; set; }

		/// <summary>
		/// A regular expression that the answer must match (for Text questions).
		/// </summary>
		public string RegExp { get; set; }

		/// <summary>
		/// The list of acceptable choices (Single and Multiple Choice answers).
		/// </summary>
		public List<QuestionnaireChoice> Choices { get; set; }

		/// <summary>
		/// A suggested number of rows to use when displaying a Text answer.
		/// </summary>
		public int? Rows { get; set; }

		/// <summary>
		/// A suggested number of columns to use when displaying a Text answer.
		/// </summary>
		public int? Columns { get; set; }

		// Picture question properties
		/// <summary>
		/// The number of pixels to be present in the longest edge of a Picture question.
		/// Eg: 2560 will allow a 2560x1280 landscape image or a 1280x2560 portrait image.
		/// </summary>
		public int? Resolution { get; set; }

		// Date, Time & DateTime question properties
		/// <summary>
		/// The maximum number of days before the current date (Date and Date/Time answers).
		/// </summary>
		public int? DaysPrior { get; set; }

		/// <summary>
		/// The maximum number of days after the current date (Date and Date/Time answers).
		/// </summary>
		public int? DaysPost { get; set; }

		/// <summary>
		/// The earliest acceptable time (Time and Date/Time answers).
		/// </summary>
		public string MinTime { get; set; }

		/// <summary>
		/// The latest acceptable time (Time and Date/Time answers).
		/// </summary>
		public string MaxTime { get; set; }
	}

	public class QuestionnaireChoice
	{
		public int ChoiceID { get; set; }
		public string Caption { get; set; }
	}

	public class QuestionnaireItemList
	{
		public int ItemListID { get; set; }
		public List<QuestionnaireItem> Items { get; set; }
	}

	public class QuestionnaireItem
	{
		public int ItemID { get; set; }
		public string Caption { get; set; }
		public Dictionary<string,string> Attributes { get; set; }
		public DateTime? EarliestDate { get; set; }
		public DateTime? LatestDate { get; set; }
	}

	public class QuestionnaireItemListRefererence
	{
		public int ItemListID { get; set; }
		public string SortBy { get; set; }
		public string GroupBy { get; set; }
		public string SearchBy { get; set; }
	}
}
