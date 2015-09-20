using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace TeamHaven.WebApi.Client
{
	/// <summary>
	/// The ITeamHavenHttpClient interface defines a very simple subset of the HttpClient's
	/// functionality to make it easy to test higher level classes.
	/// </summary>
	public interface ITeamHavenHttpClient
	{
		Task<HttpResponseMessage> GetAsync(string requestUri);
	}
}