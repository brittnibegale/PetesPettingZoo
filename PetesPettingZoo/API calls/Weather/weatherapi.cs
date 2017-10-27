using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace PetesPettingZoo.API_calls
{
    public static class weatherapi
    {
        public static List<string> ApiCall()
        {
            char[] delimiterChars = {'{','}',',','.',':','/'};
            var client = new RestClient("https://api.darksky.net/forecast/41a45e8d25e421b7a54c31009b55fe85/42.951596,-88.007835?exclude=minutely%2Chourly%2Ccurrently");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "90464e12-de20-99d8-94b1-351c4e9f6a12");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            var response1 = response.Content.Split(delimiterChars);
            List<string> result = new List<string>();

            result.Add(response1[23]);
            result.Add(response1[124]);
            result.Add(response1[224]);
            result.Add(response1[324]);
            result.Add(response1[424]);

            return result;
        }       
    }
}