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
        public static string ApiCall()
        {
            var client = new RestClient("https://api.darksky.net/forecast/41a45e8d25e421b7a54c31009b55fe85/42.951596,-88.007835?exclude=minutely%2Chourly%2Ccurrently");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "90464e12-de20-99d8-94b1-351c4e9f6a12");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            WeatherAPI weather = new WeatherAPI();

            weather = new JavaScriptSerializer().Deserialize<WeatherAPI>(response.Content);
          
            string hi = "hi";
            return hi;
        }
        public partial class WeatherAPI
        {
            public static WeatherAPI FromJson(string json) => JsonConvert.DeserializeObject<WeatherAPI>(json, Converter.Settings);
        }

       

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
}