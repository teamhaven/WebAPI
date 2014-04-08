using System;

namespace TeamHaven.WebApi.Models
{
	public enum CallStatus
	{
		/// <summary>
		/// Call is being planned and is not currently visible to the assigned User.
		/// </summary>
		BeingPlanned = 1,

		/// <summary>
		/// Call is available to the assigned user (although it may not be visible depending on it's execution window).
		/// </summary>
		Active = 2,

		/// <summary>
		/// The Call has been completed.
		/// </summary>
		Completed = 3,

		/// <summary>
		/// The Call was cancelled.
		/// </summary>
		Cancelled = 4
	}
}
