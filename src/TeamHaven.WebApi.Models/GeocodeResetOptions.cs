using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public class GeocodeResetOptions
	{
		public bool? ResetFailed { get; set; }
		public bool? ResetApproximate { get; set; }
		public bool? ResetAccurate { get; set; }
		public bool? ResetNoPosition { get; set; }

		public int? ProjectID { get; set; }
	}
}
