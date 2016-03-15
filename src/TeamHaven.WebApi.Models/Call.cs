using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Call
	{
		/// <summary>
		/// The Call's unique ID.
		/// </summary>
		public int? CallID { get; set; }

		/// <summary>
		/// The Project ID of the Project that this Call belongs to.
		/// </summary>
		public int? ProjectID { get; set; }

		/// <summary>
		/// The Target ID of the Target that this Call is visiting.
		/// </summary>
		public int? TargetID { get; set; }

		/// <summary>
		/// The User ID of the User who has been assigned to the Call.
		/// </summary>
		public int? UserID { get; set; }

		/// <summary>
		/// The Questionnaire ID of the Questionnaire that must be answered during the Call.
		/// </summary>
		public int? QuestionnaireID { get; set; }

		/// <summary>
		/// The earliest date on which this Call can be made.
		/// </summary>
		public DateTime? EarliestDate { get; set; }

		/// <summary>
		/// The latest date by which this Call can be made.
		/// </summary>
		public DateTime? LatestDate { get; set; }

		/// <summary>
		/// The date (and optionally time) when the assigned User is expecting to make Call.
		/// </summary>
		public DateTime? PlannedStart { get; set; }

		/// <summary>
		/// The estimated duration of the visit in minutes.
		/// </summary>
		public int? PlannedDuration { get; set; }

		/// <summary>
		/// The estimated travel time & distance required to reach the Call. May
		/// be NULL if the Call has no planned travel information.
		/// </summary>
		public JourneyLeg PlannedTravel { get; set; }

		/// <summary>
		/// The estimated travel time & distance requried to return home after
		/// the Call has been completed. Only present if this is the last Call
		/// planned for a day by the Call Planner, NULL otherwise.)
		/// </summary>
		public JourneyLeg PlannedHomeTravel { get; set; }

		/// <summary>
		/// The Call's status
		/// </summary>
		public CallStatus? Status { get; set; }

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

		/// <summary>
		/// The position captured when the Collector completed the Call, if known.
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// If TRUE then this Call is a Fixed Appointment and the Planned Start can not
		/// be changed by the Collector assigned to it.
		/// </summary>
		public bool? FixedAppointment { get; set; }
	}
}
