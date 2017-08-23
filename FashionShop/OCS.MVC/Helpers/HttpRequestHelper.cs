using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OCS.MVC.Controllers
{
    public static class HttpRequestHelper
    {
        private static string ServerAddr => ConfigurationManager.AppSettings["base-url"];
        private static string Token { get; set; } = "";

        private static HttpClient GetClient()
        {
            HttpClient HttpClient = new HttpClient();

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (Token.Length > 0)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }

            return HttpClient;
        }

        public static void SetAuthToken(string token)
        {
            Token = token;
        }
        
        public static async Task<HttpResponseMessage> GetAsync(string url, string param="")
        {
            HttpClient client = GetClient();
            var urlParam = Uri.UnescapeDataString(param);
            var response = await client.GetAsync( $"{ServerAddr}{url}{urlParam}");
            return response;
        }
        
        public static async Task<HttpResponseMessage> PostAsync(string url)
        {
            //!HERE!
            return null;
        }
    }

    
}