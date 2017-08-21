using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace OCS.MVC.Controllers
{
    public static class HttpRequestHelper
    {
        private static string ServerAddr { get; set; } = "https://localhost:44384/";

        private static HttpClient HttpClient { get; set; } = GetClient();

        private static HttpClient GetClient()
        {
            HttpClient HttpClient = new HttpClient();

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return HttpClient;
        }
        public static void SetAuthToken(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
        }

        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpClient client = GetClient();

            var response = await client.GetAsync(ServerAddr+url);

            return response;
        }
        public static async Task<HttpResponseMessage> PostAsync(string url)
        {
            //!HERE!
            return null;
        }
    }

    
}