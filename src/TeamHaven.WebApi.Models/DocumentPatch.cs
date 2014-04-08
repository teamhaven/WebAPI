using System;

namespace TeamHaven.WebApi.Models
{
	public class DocumentPatch
	{
		/// <summary>
		/// If not null, the new Document Category
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// If not null, the new display sequence (0 is first)
		/// </summary>
		public int? Sequence { get; set; }
	}
}
