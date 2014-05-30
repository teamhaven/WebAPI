using System;
using System.Text;
using System.Net.Http;

using TeamHaven.WebApi.Proxy;

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
            var client = CreateHttpClient(Username, Password, Account, useHttpForEasyDebugging: true);
            var proxy = new TeamHavenProxy(client);

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
                        Console.WriteLine("{0} {1} {2}", e.Object.ObjectType, e.Object.ObjectID, e.EventType);
                        return true;
                    },

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

        static HttpClient CreateHttpClient(string username, string password, string account = null, bool useHttpForEasyDebugging = false)
        {
            var server = new Uri(useHttpForEasyDebugging ? "http://www.teamhaven.com" : "https://www.teamhaven.com");
            var client = new HttpClient { BaseAddress = server };

            // Identify the application to TeamHaven
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", String.Format("app={0}; email={1}", ApplicationName, ApplicationEmail));

            // Provide the credentials to authorise requests with
            var credentials = String.Format(account == null ? "{0}:{1}" : "{0}/{2}:{1}", username, password, account).ToBase64();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials);

            // Request JSON encoded responses using the most recent version of the API
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.teamhaven+json");

            return client;
        }
    }

    static class StringExtensions
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
