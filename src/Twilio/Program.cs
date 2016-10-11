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

            var request = new RestRequest("Accounts/ACa2c31d7210c8e998dec91c784b4e922e/Messages", Method.POST);

            request.AddParameter("To", "+19417308602");
            request.AddParameter("From", "+12067178858");
            request.AddParameter("Body", "Islands in the Stream");

            client.Authenticator = new HttpBasicAuthenticator("ACa2c31d7210c8e998dec91c784b4e922e", "348a8cd48582b1a8289e1bc3db41cd08");

            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response);
            });
            Console.ReadLine();
        }
    }
}
