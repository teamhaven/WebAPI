using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Project
	{
		public int? ProjectID { get; set; }

		/// <summary>
		/// Project's name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Project's description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// A optional reference (eg ABC123)
		/// </summary>
		public string Reference { get; set; }

		/// <summary>
		/// UserID of the person to contact about this project
		/// </summary>
		public int? ContactUserID { get; set; }

		/// <summary>
		/// The number of days before the Earliest Date that Calls become visible to Collectors
		/// </summary>
		public int PreviewMargin { get; set; }

		/// <summary>
		/// The number of days before the Latest Date after which incomplete Calls become critical
		/// </summary>
		public int CriticalMargin { get; set; }

		/// <summary>
		/// The number of days after the Latest Date after which Calls are hidden from Collectors
		/// </summary>
		public int ExpiryMargin { get; set; }

		/// <summary>
		/// If TRUE then Collectors can update the Answers to completed Calls
		/// </summary>
		public bool CollectorCanUpdateCalls { get; set; }

		/// <summary>
		/// If TRUE then Collectors can create new Calls to Targets where they have been
		/// assigned as the Default User.
		/// </summary>
		public bool CollectorCanCreateCalls { get; set; }

		/// <summary>
		/// The lowest Role allowed to change the Questionnaire design
		/// </summary>
		public Role DesignRole { get; set; }

		/// <summary>
		/// If TRUE then this project is included in the Payroll reports
		/// </summary>
		public bool IncludedInPayroll { get; set; }

		/// <summary>
		/// AttributeID of a Project Target Attribute to group Calls by on TeamHaven Mobile
		/// </summary>
		public int? MobileGroupingAttributeID { get; set; }

		/// <summary>
		/// If TRUE then completed Calls are kept on the device until they pass their Expiry Date
		/// </summary>
		public bool RetainCompletedCalls { get; set; }

		/// <summary>
		/// If TRUE then access to the device's photo library will not be permitted when answering picture questions
		/// </summary>
		public bool PreventPhotoLibraryAccess { get; set; }

		/// <summary>
		/// If Project Target does not specify a Country, then this is used while Geocoding
		/// </summary>
		public string DefaultCountry { get; set; }

		/// <summary>
		/// How TeamHaven Mobile should handle Checkins.
		/// 0 - Off (Collectors are not shown the check-in and check-out options)
		/// 1 - Required (Collectors MUST check-in and check-out of calls)
		/// </summary>
		public CheckinMode? CheckinMode { get; set; }

		/// <summary>
		/// Maps the old and obsolete CheckinMode to a simple boolean
		/// </summary>
		public bool CheckinsEnabled
		{
			get { return CheckinMode.HasValue && CheckinMode.Value != TeamHaven.WebApi.Models.CheckinMode.Off; }
			set { CheckinMode = value ? TeamHaven.WebApi.Models.CheckinMode.Required : TeamHaven.WebApi.Models.CheckinMode.Off; }
		}

		/// <summary>
		/// If TRUE then the device's Location Services must be turned on in order to check-in.
		/// (It might not be able to give you a location, but at least it's trying)
		/// </summary>
		public bool CheckinsRequireLocationServices { get; set; }

		/// <summary>
		/// If TRUE then users can still check-in even when their device
		/// is not reporting an accurate location.
		/// </summary>
		public bool AllowApproximateCheckins { get; set; }

		/// <summary>
		/// If TRUE then users can still check-in even if their device is
		/// not reporting a location at all.
		/// </summary>
		public bool AllowUnknownCheckins { get; set; }

		/// <summary>
		/// The maximum distance in meters between the Target and the User's
		/// device beyond which the check-in is considered "bad".
		/// </summary>
		public int? CheckinDistanceLimit { get; set; }

		/// <summary>
		/// If TRUE and the distance between the device and the Target is
		/// accurate, then users must be within the distance limit in order to
		/// be able to check in.
		/// 
		/// Used when both the Target and the device have accurate positions.
		/// </summary>
		public bool EnforceAccurateDistanceLimit { get; set; }

		/// <summary>
		/// If TRUE and the distance between the device and the Target is only
		/// approximately known, then users must be within the distance limit in
		/// order to be able to check in.
		/// 
		/// Used when either the Target or the device do not have accurate positions.
		/// </summary>
		public bool EnforceApproximateDistanceLimit { get; set; }

		/// <summary>
		/// If TRUE, the check-in and check-out times are verified using an internet
		/// time server to ensure device times are correct. If device times are
		/// incorrect, the verified time is used.
		/// </summary>
		public bool EnforceTimeVerification { get; set; }

		/// <summary>
		/// If TRUE, synchronisation will take place on save.
		/// </summary>
		public bool SyncOnSave { get; set; }

		public bool SelfAssignment { get; set; }

		public int? SelfAssignmentMargin { get; set; }
	}
}
