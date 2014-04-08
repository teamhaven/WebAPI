using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class DocumentGrouping
	{
		/// <summary>
		/// Which Account owns this grouping. May be null
		/// if the Documents are global.
		/// </summary>
		public int? AccountID { get; set; }

		/// <summary>
		/// Which Project owns this grouping. May be null
		/// if the Documents are not Project specific.
		/// </summary>
		public int? ProjectID { get; set; }

		/// <summary>
		/// The name of this grouping.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A list of the Documents in this grouping.
		/// </summary>
		public List<Document> Documents { get; set; }
	}
}
