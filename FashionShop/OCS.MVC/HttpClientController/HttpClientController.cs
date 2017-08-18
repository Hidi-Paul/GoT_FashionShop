using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens;

namespace OCS.MVC.HttpClientController
{
    public class HttpClientController
    {
        public HttpClient client;

        public HttpClientController(string token)
        {
           
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44384/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }

    }

    
}