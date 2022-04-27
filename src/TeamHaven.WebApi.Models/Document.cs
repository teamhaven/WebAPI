using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public class Document
	{
		/// <summary>
		/// Unique Document ID
		/// </summary>
		public int DocumentID { get; set; }

		/// <summary>
		/// AccountID this Document belongs to. May be
		/// null if it is a global document visible to
		/// all accounts.
		/// </summary>
		public int? AccountID { get; set; }

		/// <summary>
		/// ProjectID this Document belongs to. May be
		/// null if it is not associated with a specific
		/// Project.
		/// </summary>
		public int? ProjectID { get; set; }

		/// <summary>
		/// The Document's Title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Optional description for the Document.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The Category this Document is grouped under.
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Link to follow when Document is clicked on.
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// URL of an icon representing the Document.
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// Who can view the Document.
		/// </summary>
		public DocumentPermissions Permissions { get; set; }

		/// <summary>
		/// The document type
		/// </summary>
		public DocumentType DocumentType { get; set; }

		/// <summary>
		/// The document's Media Type
		/// </summary>
		public string MediaType { get; set; }
	}
}
