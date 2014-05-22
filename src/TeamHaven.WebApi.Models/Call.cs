using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Call
	{
		/// <summary>
		/// The Call's unique ID.
		/// </summary>
		public int CallID { get; set; }

		/// <summary>
		/// The Project ID of the Project that this Call belongs to.
		/// </summary>
		public int ProjectID { get; set; }

		/// <summary>
		/// The Target ID of the Target that this Call is visiting.
		/// </summary>
		public int TargetID { get; set; }

		/// <summary>
		/// The User ID of the User who has been assigned to the Call.
		/// </summary>
		public int? UserID { get; set; }

		/// <summary>
		/// The Questionnaire ID of the Questionnaire that must be answered during the Call.
		/// </summary>
		public int QuestionnaireID { get; set; }

		/// <summary>
		/// The earliest date on which this Call can be made.
		/// </summary>
		public DateTime EarliestDate { get; set; }

		/// <summary>
		/// The latest date by which this Call can be made.
		/// </summary>
		public DateTime LatestDate { get; set; }

		/// <summary>
		/// The date (and optionally time) when the assigned User is expecting to make Call.
		/// </summary>
		public DateTime? PlannedStart { get; set; }

		/// <summary>
		/// The estimate duration of the visit in minutes.
		/// </summary>
		public int? PlannedDuration { get; set; } 

		/// <summary>
		/// The Call's status
		/// </summary>
		public CallStatus Status { get; set; }

		/// <summary>
		/// The date (and optionally time) when the visit was made.
		/// This may be null if the questionnaire does not have the requisite question bindings.
		/// </summary>
		public DateTime? ActualStart { get; set; }

		/// <summary>
		/// The visit duration in minutes.
		/// This may be null if the questionnaire does not have the requisite question bindings.
		/// </summary>
		public int? ActualDuration { get; set; }

		/// <summary>
		/// A dictionary of the Attribute Values assigned to the Call.
		/// </summary>
		public Dictionary<string, string> Attributes { get; set; }

		/// <summary>
		/// A copy of the Project's Call Attribute Schema, if requested.
		/// </summary>
		public List<AttributeDefinition> Schema { get; set; }
	}
}
