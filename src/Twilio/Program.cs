using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Twilio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");

            var request = new RestRequest("Accounts/ACa2c31d7210c8e998dec91c784b4e922e/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator("ACa2c31d7210c8e998dec91c784b4e922e", "348a8cd48582b1a8289e1bc3db41cd08");

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response.Content);
            Console.ReadLine();
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
