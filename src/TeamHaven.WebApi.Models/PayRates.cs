using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	public enum PayrollMode
	{
		/// <summary>
		/// Not included in the payroll
		/// </summary>
		NotPaid = 0,

		/// <summary>
		/// The rate is paid per-hour of ActualDuration
		/// </summary>
		Hourly = 1,

		/// <summary>
		/// The rate is paid once per completed call
		/// </summary>
		PerCall = 2
	}

	public class ProjectPayRates : PayRates
	{
		public PayrollMode PayrollMode { get; set; }
		public int? LabourRateOverrideTargetAttributeID { get; set; }
		public int? ExpenseRateOverrideTargetAttributeID { get; set; }
	}

	public class PayRates
	{
		/// <summary>
		/// Instore time pay rate
		/// </summary>
		public decimal? LabourRate { get; set; }

		/// <summary>
		/// Pay rate for expenses
		/// </summary>
		public decimal? ExpenseRate { get; set; }
	}
}
