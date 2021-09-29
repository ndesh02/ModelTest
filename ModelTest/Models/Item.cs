using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ModelTest.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public static HttpClient imageClient = new HttpClient();
        public static bool isInitialized = false;
        public static JObject results = new JObject();
        public static void Initialize()
        {
            if (!isInitialized)
            {
                imageClient.BaseAddress = new Uri("http://192.168.3.115:5000/");
                
                imageClient.Timeout = TimeSpan.FromSeconds(60);
            }
        }
    }
}