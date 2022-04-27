using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public class SearchResults
	{
		public List<UserSearchResult> Users { get; set; }
		public List<TargetSearchResult> Targets { get; set; }
		public List<CallSearchResult> Calls { get; set; }
		public List<ProjectSearchResult> Projects { get; set; }
	}
}
