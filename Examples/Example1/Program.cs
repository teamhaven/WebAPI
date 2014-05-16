using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using TeamHaven.WebApi;
using TeamHaven.WebApi.Models;

namespace Example1
{
    class Program
    {
        // These strings identify your application to TeamHaven so we know
        // who to get in touch with in case we need to
        const string ApplicationName = "My Application";
        const string ApplicationEmail = "me@mycompany.com";

        // Virtually all of the TeamHaven Web API requires authorisation.
        // Replace these values with your own TeamHaven credentials.
        const string Username = "my username";
        const string Password = "my password";
        const string Account = "my account";

        static void Main(string[] args)
        {
            // Create an HttpClient instance and initialise it with TeamHaven specific defaults
            var httpClient = CreateHttpClient(Username, Password, Account, useHttpForEasyDebugging: true);

            // Create a proxy that fetches data using the HttpClient we just created
            var proxy = new TeamHavenProxy(httpClient);


            // Example: Use the proxy to call the Server Information API
            proxy.GetServerInfo().ContinueWith(x =>
            {
                Console.WriteLine("Server identifies itself as " + x.Result.Name);
                Console.WriteLine("Server's preferred base address is " + (x.Result.HttpsUrl ?? x.Result.HttpUrl));
            });


            // Example: Display some information about the authenticated user
            proxy.GetUser().ContinueWith(x => Console.WriteLine("Authorized as " + x.Result.DisplayName));


            Console.ReadKey();
        }

        /// <summary>
        /// Helper method that creates a .NET HttpClient and initialises to connect to the main TeamHaven server.
        /// You must supply a valid TeamHaven Username, Password and Account in order for Web API requests to be
        /// authorized correctly.
        /// 
        /// We recommend that you always connect to the HTTPS version of the Web API, but for debugging purposes,
        /// it can be convienient to use the HTTP version so that you can easily examine requests using a network sniffer.
        /// </summary>
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
