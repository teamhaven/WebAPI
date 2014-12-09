using System;
using System.Collections.Generic;
using System.Linq;

using TeamHaven.WebApi.Client;
using TeamHaven.WebApi.Models;

namespace Example3
{
	class Program
	{
		// These strings identify your application to TeamHaven so we know
		// who to get in touch with in case we need to
		const string ApplicationName = "Picture downloading example";
		const string ApplicationEmail = "me@mycompany.com";

		// Virtually all of the TeamHaven Web API requires authorisation.
		// Replace these values with your own TeamHaven credentials.
		const string Username = "myusername";
		const string Password = "mypassword";
		const string Account = "myaccount";

		const string Server = "www.teamhaven.com";

		static void Main(string[] args)
		{
			var client = TeamHavenClient.CreateHttpClient(ApplicationName, ApplicationEmail, Username, Password, Account, useHttpForEasyDebugging: true, serverUrl: Server);
			var proxy = new TeamHavenClient(client);

			var pictureSaver = new PictureSavingCallProcessor(proxy);

			var monitor = new IntegrationEventMonitor
			{
				// Use the TeamHaven WebAPI to retrieve the information needed to access the Windows Azure queue
				GetQueueAccessInformation = () =>
				{
					var task = proxy.GetEventsAuthorisation();
					return task.Result;
				},

				// This code processes a single IntegrationEvent and should return TRUE if the event
				// was successfully processed.
				ProcessEvent = (e) => 
				{
					if (e.Object.ObjectType == ObjectType.Call && e.EventType == IntegrationEventType.Answered)
					{
						var task = pictureSaver.Process(e);
						task.Wait();
						return task.Result;
					}
					return true;
				},

				// This code should return TRUE until you want the monitoring loop to stop
				ContinueMonitoring = () => true,

				// This code handles errors thrown by the ProcessEvent delegate. It should return TRUE if
				// the failed message should be deleted from the queue.
				OnError = (ex, msg) =>
				{
					Console.WriteLine(ex.Message);

					// The message causing the error is not deleted so that you have a chance to investigate and
					// process it correctly. Make sure you never delete mesasges that you have not processed!
					// Consider moving failures into an Azure Queue of your own, or to some other persistent medium
					// so that you can clear them out of the main processing queue.
					return false;
				}
			};

			// Start the monitoring loop
			monitor.MonitorQueue();
		}
	}
}