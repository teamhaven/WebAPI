using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// This class represents the experience that a user has attained in a particular skill.
	/// </summary>
	public class UserExperience
	{
		/// <summary>
		/// The unique SkillID of the skill.
		/// </summary>
		public int SkillID { get; set; }

		/// <summary>
		/// The name of the skill.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The level the user has attained in the skill.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// How much experience the user has in the skill.
		/// </summary>
		public int Experience { get; set; }

		/// <summary>
		/// How much experience was required to reach the current level.
		/// </summary>
		public int ThisLevelExperience { get; set; }

		/// <summary>
		/// How much experience is required to reach the next level.
		/// (This is an absolute number: NextLevelExperience - Experience
		/// is how much more experience the user must earn)
		/// </summary>
		public int? NextLevelExperience { get; set; }
	}
}
