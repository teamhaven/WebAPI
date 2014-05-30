using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

using TeamHaven.WebApi.Proxy;
using TeamHaven.WebApi.Models;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

using Newtonsoft.Json;

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

    /// <summary>
    /// This class implements a simple message processing loop that demonstrates
    /// how TeamHaven IntegrationEvent queues can be monitored
    /// </summary>
    public class IntegrationEventMonitor
    {
        /// <summary>
        /// This delegate is called whenever the monitor needs authorisation to access the Azure Storage Queue. It
        /// should return an AzureQueueAccessInformation instance.
        /// </summary>
        public Func<AzureQueueAccessInformation> GetQueueAccessInformation { get; set; }

        /// <summary>
        /// This delegate is called whenever a new IntegrationEvent is received. Once it has finished processing
        /// the event, it should return true to have the event deleted from the queue.
        /// </summary>
        public Func<IntegrationEvent, bool> ProcessEvent { get; set; }

        /// <summary>
        /// This delegate is called to determine whether the monitoring loop should continue.
        /// </summary>
        public Func<bool> ContinueMonitoring { get; set; }

        /// <summary>
        /// This delegate is called when an exception is thrown during the processing of a queue message. It
        /// should return true if the message should be deleted from the queue.
        /// </summary>
        public Func<Exception, CloudQueueMessage, bool> OnError { get; set; }

        CloudQueue queue = null;

        /// <summary>
        /// The MonitorQueue method fetches and processes messages from the queue that is identified by calling GetQueueAccessInformation.
        /// It will continue to process messages until ContinueMonitoring returns false.
        /// The ProcessMessage delegate is used to process each message, and if the processing fails, the OnError delegate is called.
        /// Both ProcessMessage and OnError should return TRUE to indicate that the message should be deleted from the queue.
        /// </summary>
        public void MonitorQueue()
        {
            AzureQueueAccessInformation accessInfo = null;

            while (ContinueMonitoring == null || ContinueMonitoring())
            {
                // If we don't have valid queue access information then get some
                if (accessInfo == null || DateTime.UtcNow.AddHours(-1) > accessInfo.Expires)
                {
                    accessInfo = GetQueueAccessInformation();
                    queue = null;
                }

                // Get a reference to the Azure queue
                if (queue == null) queue = GetQueueReference(accessInfo);

                // Process the next message
                var message = queue.GetMessage();
                if (message != null)
                {
                    var delete = ProcessMessage(message);
                    if (delete) queue.DeleteMessage(message);
                }

                // Wait a little bit before checking the queue again if we didn't
                // get a message
                if (message == null) Thread.Sleep(1000);
            }
        }

        CloudQueue GetQueueReference(AzureQueueAccessInformation accessInfo)
        {
            var creds = new StorageCredentials(accessInfo.Token);
            var uri = new Uri(accessInfo.StorageUri.PrimaryUri);
            var client = new CloudQueueClient(uri, creds);
            var queue = client.GetQueueReference(accessInfo.QueueName);
            return queue;
        }

        /// <summary>
        /// Processes a cloud message and returns TRUE if the message
        /// should be deleted from the queue. If the processing
        /// resulted in an exception being thrown, the result of
        /// calling the OnError delegate is returned, otherwise
        /// the exception is re-thrown.
        /// </summary>
        bool ProcessMessage(CloudQueueMessage message)
        {
            try
            {
                // Deserialize the JSON payload
                var e = JsonConvert.DeserializeObject<IntegrationEvent>(message.AsString);

                // If we have a ProcessEvent delegate, then process the message
                return ProcessEvent != null ? ProcessEvent(e) : false;
            }
            catch (Exception ex)
            {
                // If we have an error handler, then delegate to it
                if (OnError != null) return OnError(ex, message);
                throw;
            }
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
