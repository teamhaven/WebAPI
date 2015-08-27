using System;
using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// An individual Skill Requirement for a Project.
	/// </summary>
	public class SkillRequirement
	{
		/// <summary>
		/// The unique ID for the Skill.
		/// When setting Skill Profiles, this is required.
		/// </summary>
		public int? SkillID { get; set; }

		/// <summary>
		/// The descriptive name for the Skill. This is only for
		/// information purposes, changing it will have no affect.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// If not-null and greater than zero, then Collectors must
		/// have at least that level of proficiency in the skill.
		/// </summary>
		public int? Level { get; set; }

		/// <summary>
		/// When retrieving a Target's Skill Profile, this indicates the
		/// Project's original value which the Target's own Profile is
		/// overriding.
		/// </summary>
		public int? Original { get; set; }
	}
}
