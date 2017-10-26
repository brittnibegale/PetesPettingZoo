using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetesPettingZoo.API_calls
{
    public static class mailgunAPIcall
    {
        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "key-6d66529dcd78cd88673bb52e0d1c2d84");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxf0cfd592f16443d4a6eeff871c48639e.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxf0cfd592f16443d4a6eeff871c48639e.mailgun.org>");
            request.AddParameter("to", "Brittni Begale <brittnibegale@gmail.com>");
            request.AddParameter("subject", "Hello Brittni Begale");
            request.AddParameter("text", "Thank you for your payment! We look forward to seeing you at the Pete's Petting Zoo!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}