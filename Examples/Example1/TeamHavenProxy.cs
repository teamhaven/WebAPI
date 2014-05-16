using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using TeamHaven.WebApi.Models;

namespace TeamHaven.WebApi
{
    /// <summary>
    /// An example of how to build a proxy that wraps the TeamHaven Web API so that you can use "real" objects
    /// rather than deal with JSON encoding & decoding.
    /// </summary>
    public class TeamHavenProxy
    {
        HttpClient client;

        public TeamHavenProxy(HttpClient client)
        {
            this.client = client;
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
            var response = await client.GetAsync("/calls/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Call>();
        }
    }
}
