using System;
using System.Threading;

using TeamHaven.WebApi.Models;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

using Newtonsoft.Json;

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
    public Action<IntegrationEvent> ProcessEvent { get; set; }

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
				try
				{
					accessInfo = GetQueueAccessInformation();
					queue = null;
				}
				catch (AggregateException ex)
				{
					// If we have an error handler, then delegate to it
					if (OnError != null) OnError(ex.InnerException, null);
					return; // Abort
				}
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
			if (ProcessEvent != null) ProcessEvent(e);
			return true;
        }
        catch (Exception ex)
        {
            // If we have an error handler, then delegate to it
            if (OnError != null) return OnError(ex, message);

			// Otherwise re-throw the exception
            throw;
        }
    }
}
