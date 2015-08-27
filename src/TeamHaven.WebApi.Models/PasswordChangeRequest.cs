using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class PasswordChangeRequest
	{
		/// <summary>
		/// The old password
		/// </summary>
		public string OldPassword { get; set; }

		/// <summary>
		/// The new password
		/// </summary>
		public string NewPassword { get; set; }
	}
}
