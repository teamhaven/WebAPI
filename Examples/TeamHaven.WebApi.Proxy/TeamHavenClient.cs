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
        HttpClient client;

        public TeamHavenClient(HttpClient client)
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
		public static HttpClient CreateHttpClient(string appName, string appEmail, string username, string password, string account = null, bool useHttpForEasyDebugging = false)
		{
			var server = new Uri(useHttpForEasyDebugging ? "http://www.teamhaven.com" : "https://www.teamhaven.com");
			var client = new HttpClient { BaseAddress = server };

			// Identify the application to TeamHaven
			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", String.Format("app={0}; email={1}", appName, appEmail));

			// Provide the credentials to authorise requests with
			var credentials = String.Format(account == null ? "{0}:{1}" : "{0}/{2}:{1}", username, password, account).ToBase64();
			client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials);

			// Request JSON encoded responses using the most recent version of the API
			client.DefaultRequestHeaders.Add("Accept", "application/vnd.teamhaven+json");

			return client;
		}

        public async Task<ServerInfo> GetServerInfo()
        {
            var response = await client.GetAsync("/api/server");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ServerInfo>();
        }

        public async Task<User> GetUser(int? id = null)
        {
            var url = id == null ? "/api/user" : "/api/users/" + id;
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<User>();
        }

        public async Task<Call> GetCall(int id)
        {
            var response = await client.GetAsync("/api/calls/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Call>();
        }

        public async Task<List<Answer>> GetCallAnswers(int id)
        {
            var response = await client.GetAsync("/api/calls/" + id + "/answers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<Answer>>();
        }

        public async Task<Questionnaire> GetCallQuestionnaire(int id)
        {
            var response = await client.GetAsync("/api/calls/" + id + "/questionnaire");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Questionnaire>();
        }

        public async Task<QuestionnaireManifest> GetCallQuestionnaireManifest(int id)
        {
            var response = await client.GetAsync("/api/calls/" + id + "/questionnaire/manifest");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<QuestionnaireManifest>();
        }

        public async Task<AzureQueueAccessInformation> GetEventsAuthorisation()
        {
            var response = await client.GetAsync("/api/events/authorisation");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<AzureQueueAccessInformation>();
        }
    }
}
