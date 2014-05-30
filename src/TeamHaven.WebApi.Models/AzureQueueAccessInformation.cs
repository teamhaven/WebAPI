using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamHaven.WebApi.Models
{
	/// <summary>
	/// Class encapsulating all the information required to create an SAS token
	/// for accessing a Windows Azure Storage Queue.
	/// </summary>
	public class AzureQueueAccessInformation
	{
		/// <summary>
		/// A temporary access token that can be used to access the queue until
		/// it expires.
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// UTC date/time indicating when the temporary access token will expire.
		/// </summary>
		public DateTime Expires { get; set; }

		/// <summary>
		/// The URIs that can be used to access the queue.
		/// </summary>
		public StorageUri StorageUri { get; set; }

		/// <summary>
		/// The name of the queue.
		/// </summary>
		public string QueueName { get; set; }
	}

	/// <summary>
	/// The URIs that can be used to connect to an Azure Storage Account.
	/// </summary>
	public class StorageUri
	{
		public string PrimaryUri { get; set; }
		public string SecondaryUri { get; set; }
	}
}
