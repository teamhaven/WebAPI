using System;
using System.Collections.Generic;
using System.Linq;

using TeamHaven.WebApi.Client;

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
            var httpClient = TeamHavenClient.CreateHttpClient(ApplicationName, ApplicationEmail, Username, Password, Account, useHttpForEasyDebugging: true);

            // Create a proxy that fetches data using the HttpClient we just created
            var proxy = new TeamHavenClient(httpClient);

			// Example: Use the proxy to call the Server Information API
			proxy.GetServerInfo().ContinueWith(x =>
			{
				if (!x.IsFaulted)
				{
					Console.WriteLine("Server identifies itself as " + x.Result.Name);
					Console.WriteLine("Server's preferred base address is " + (x.Result.HttpsUrl ?? x.Result.HttpUrl));
				}
				else
				{
					Console.WriteLine("/api/server failed: ", x.Exception.InnerException.Message);
				}
			});

			// Example: Display some information about the authenticated user
			proxy.GetUser().ContinueWith(x => 
			{
				if (!x.IsFaulted) Console.WriteLine("Authorized as " + x.Result.DisplayName);
				else
				{
					Console.WriteLine("/api/user failed: {0}", x.Exception.InnerException.Message);
				}
			});

            Console.ReadKey();
        }
    }
}
