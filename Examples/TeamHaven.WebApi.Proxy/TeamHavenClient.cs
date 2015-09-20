using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

using TeamHaven.WebApi.Models;

namespace TeamHaven.WebApi.Client
{
    /// <summary>
    /// An example of how to build a proxy that wraps the TeamHaven Web API so that you can use "real" objects
    /// rather than deal with JSON encoding & decoding.
    /// </summary>
    public class TeamHavenClient
    {
        ITeamHavenHttpClient client;

        public TeamHavenClient(ITeamHavenHttpClient client)
        {
            this.client = client;
        }

		/// <summary>
		/// Helper method that creates a .NET HttpClient and initialises to connect to the main TeamHaven server.
		/// You must supply a valid TeamHaven Username, Password and Account in order for Web API requests to be
		/// authorized correctly.
		/// 
		/// We recommend that you always connect to the HTTPS version of the Web API, but for debugging purposes,
		/// it can be convienient to use the HTTP version so that you can easily examine requests using a network sniffer.
		/// </summary>
		public static ITeamHavenHttpClient CreateHttpClient(string appName, string appEmail, string username, string password, string account = null, bool useHttpForEasyDebugging = false, string serverUrl = "www.teamhaven.com")
		{
			var serverUri = new Uri(String.Format("{0}://{1}", useHttpForEasyDebugging ? "http" : "https", serverUrl));
			var wrappedClient = new HttpClient { BaseAddress = serverUri };

			// Identify the application to TeamHaven
			wrappedClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", String.Format("app={0}; email={1}", appName, appEmail));

			// Provide the credentials to authorise requests with
			var credentials = String.Format(account == null ? "{0}:{1}" : "{0}/{2}:{1}", username, password, account).ToBase64();
			wrappedClient.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials);

			// Request JSON encoded responses using the most recent version of the API
			wrappedClient.DefaultRequestHeaders.Add("Accept", "application/vnd.teamhaven+json");

			return new TeamHavenHttpClient(wrappedClient);
		}

		/// <summary>
		/// Send a GET request to the specified URI as an asynchonous operation.
		/// If the server responds with a 429 - TOO MANY REQUESTS, the task will
		/// sleep for the server-specified retry period and then try again. The
		/// task will only complete when a response other than a 429 has been
		/// received.
		/// </summary>
		public async Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			while (true) // TODO: Waiting indefinitely is a bit naive
			{
				var response = await client.GetAsync(requestUri);

				if ((int)response.StatusCode != 429)
				{
					response.EnsureSuccessStatusCode();
					return response;
				}

				var retryAfter = response.Headers.RetryAfter.Delta ?? TimeSpan.FromSeconds(5);
				Console.WriteLine("Request limit exceeded, sleeping for {0:n0} minutes...", retryAfter.TotalMinutes);
				await Task.Delay(retryAfter);
			}
		}

        public async Task<ServerInfo> GetServerInfo()
        {
            var response = await GetAsync("/api/server");
            return await response.Content.ReadAsAsync<ServerInfo>();
        }

        public async Task<User> GetUser(int? id = null)
        {
            var url = id == null ? "/api/user" : "/api/users/" + id;
            var response = await GetAsync(url);
            return await response.Content.ReadAsAsync<User>();
        }

        public async Task<Call> GetCall(int id)
        {
            var response = await GetAsync("/api/calls/" + id);
            return await response.Content.ReadAsAsync<Call>();
        }

        public async Task<List<Answer>> GetCallAnswers(int id)
        {
            var response = await GetAsync("/api/calls/" + id + "/answers");
            return await response.Content.ReadAsAsync<List<Answer>>();
        }

        public async Task<Questionnaire> GetCallQuestionnaire(int id)
        {
            var response = await GetAsync("/api/calls/" + id + "/questionnaire");
            return await response.Content.ReadAsAsync<Questionnaire>();
        }

        public async Task<QuestionnaireManifest> GetCallQuestionnaireManifest(int id)
        {
            var response = await GetAsync("/api/calls/" + id + "/questionnaire/manifest");
            return await response.Content.ReadAsAsync<QuestionnaireManifest>();
        }

        public async Task<AzureQueueAccessInformation> GetEventsAuthorisation()
        {
            var response = await GetAsync("/api/events/authorisation");
            return await response.Content.ReadAsAsync<AzureQueueAccessInformation>();
        }

		public async Task<Target> GetTarget(int projectID, int targetID)
		{
			var response = await GetAsync("/api/projects/" + projectID + "/targets/" + targetID);
			return await response.Content.ReadAsAsync<Target>();
		}

		public async Task<byte[]> GetPicture(Guid guid)
		{
			var response = await GetAsync("/api/pictures/" + guid);
			return await response.Content.ReadAsByteArrayAsync();
		}
    }
}
