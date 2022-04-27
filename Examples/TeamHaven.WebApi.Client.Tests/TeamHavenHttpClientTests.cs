using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;

namespace TeamHaven.WebApi.Client.Tests
{
	[TestClass]
	public class TeamHavenHttpClientTests
	{
		[TestMethod]
		public void Client_Throttles_Automatically()
		{
			// Arrange
			var httpClient = A.Fake<ITeamHavenHttpClient>();
			A.CallTo(() => httpClient.GetAsync("/api/server")).ReturnsNextFromSequence(
				Task.FromResult(CreateRetryAfterResponse(TimeSpan.FromSeconds(5))),
				Task.FromResult(CreateRetryAfterResponse(TimeSpan.FromSeconds(5))),
				Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json")
				})
			);

			// Act
			var stopwatch = new System.Diagnostics.Stopwatch();
			stopwatch.Start();
			var webClient = new TeamHavenClient(httpClient);
			var info = webClient.GetServerInfo().Result;
			stopwatch.Stop();

			// Assert
			A.CallTo(() => httpClient.GetAsync("/api/server")).MustHaveHappened(3, Times.Exactly);
			Assert.AreEqual(10, (int)stopwatch.Elapsed.TotalSeconds);
		}

		HttpResponseMessage CreateRetryAfterResponse(TimeSpan retryAfter)
		{
			var response = new HttpResponseMessage((HttpStatusCode)429);
			response.Headers.RetryAfter = new RetryConditionHeaderValue(retryAfter);
			return response;
		}
	}
}
