using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Client
{
	public static class StringExtensions
	{
		/// <summary>
		/// Convert a string to Base64
		/// </summary>
		public static string ToBase64(this string input)
		{
			var bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(bytes);
		}
	}
}
