using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public static async Task<HttpResponseMessage> GetAsync(string url, string urlParam = "")
        {
            HttpClient client = GetClient();

            var response = (urlParam.Length > 0) ? await client.GetAsync($"{ServerAddr}{url}?urlParams={urlParam}") :
                                                   await client.GetAsync($"{ServerAddr}{url}");
            return response;
        }

        public static async Task<HttpResponseMessage> PostAsync(string url, Object data)
        {
            HttpClient client = GetClient();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{ServerAddr}{url}", content);

            return response;
        }
    }


}