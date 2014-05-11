using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// The display theme for an Account
	/// </summary>
	public class Theme
	{
		/// <summary>
		/// The foreground (text) colour of an accented block.
		/// </summary>
		public string AccentForegroundColor { get; set; }
		
		/// <summary>
		/// The background colour of an accented block.
		/// </summary>
		public string AccentBackgroundColor { get; set; }

		/// <summary>
		/// The border colour surrounding an accented block.
		/// Also used to as a border around boxes, and as the
		/// hover colour for hyperlinks and buttons.
		/// </summary>
		public string AccentBorderColor { get; set; }

		/// <summary>
		/// The background colour for boxes.
		/// Must look good behind black text.
		/// </summary>
		public string BoxBackgroundColor { get; set; }

		/// <summary>
		/// The URL of the logo to display.
		/// </summary>
		public string Logo { get; set; }
	}
}
