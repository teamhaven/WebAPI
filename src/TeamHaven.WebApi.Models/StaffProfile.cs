using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class StaffProfile
	{
		/// <summary>
		/// The maximum distance a Collector is able to travel in
		/// order to be considered suitable.
		/// </summary>
		public float? MaximumDistance { get; set; }

		/// <summary>
		/// A list of skills that the Project requires. Collectors will
		/// earn experience in each of these for every call they complete.
		/// If the required skill level is greater than zero, then the
		/// Collector must have at least that level of proficiency to be
		/// considered suitable.
		/// </summary>
		public List<SkillRequirement> Skills { get; set; }
	}
}
