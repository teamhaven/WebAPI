using System.Collections.Generic;

namespace TeamHaven.WebApi.Models
{
	public enum DocumentType
	{
		Unknown = -1,
		Blob = 0,
		Url = 1,
		Report = 2,
		Gallery = 3,
		PortalPage = 4,
		ColumnExport = 5,
		PivotExport = 6,
		ItemDataExport = 7,
	}
}
