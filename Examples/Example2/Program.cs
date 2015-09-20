using System;

using TeamHaven.WebApi.Client;
using TeamHaven.WebApi.Models;

namespace Example2
{
	class Program
	{
		// These strings identify your application to TeamHaven so we know
		// who to get in touch with in case we need to
		const string ApplicationName = "My Application";
		const string ApplicationEmail = "me@mycompany.com";

		// Virtually all of the TeamHaven Web API requires authorisation.
		// Replace these values with your own TeamHaven credentials.
		const string Username = "myusername";
		const string Password = "mypassword";
		const string Account = "myaccount";

		static void Main(string[] args)
		{
			var client = TeamHavenClient.CreateHttpClient(ApplicationName, ApplicationEmail, Username, Password, Account);
			var proxy = new TeamHavenClient(client);

			var monitor = new IntegrationEventMonitor
			{
				// Use the TeamHaven WebAPI to retrieve the information needed to access the Windows Azure queue
				GetQueueAccessInformation = () => proxy.GetEventsAuthorisation().Result,

				// This code processes a single IntegrationEvent and should return TRUE if the event
				// was successfully processed.
				ProcessEvent = (e) => ProcessIntegrationEvent(e),

				// This code should return TRUE until you want the monitoring loop to stop
				ContinueMonitoring = () => true,

				// This code handles errors thrown by the ProcessEvent delegate. It should return TRUE if
				// the failed message should be deleted from the queue.
				OnError = (ex, msg) =>
				{
					Console.WriteLine(ex.Message);
					return true;
				}
			};

			// Start the monitoring loop
			monitor.MonitorQueue();
		}

		/// <summary>
		/// This is where you would write your own code to handle the Integration Events
		/// </summary>
		static void ProcessIntegrationEvent(IntegrationEvent e)
		{
			Console.WriteLine("A {0} with an ID of {1} has been {2}", e.Object.ObjectType, e.Object.ObjectID, e.EventType);
		}
	}
}
