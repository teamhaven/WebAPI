using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace TeamHaven.WebApi.Client
{
	/// <summary>
	/// The TeamHavenHttpClient implements the ITeamHavenHttpClient interface. This
	/// defines a very simple subset of the HttpClient's functionality to make it
	/// easy to write tests against.
	/// </summary>
	class TeamHavenHttpClient : ITeamHavenHttpClient
	{
		HttpClient httpClient;

		public TeamHavenHttpClient(HttpClient innerClient)
		{
			this.httpClient = innerClient;
		}

		public async Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return await httpClient.GetAsync(requestUri);
		}
	}
}
