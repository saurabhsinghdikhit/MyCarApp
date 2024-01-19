using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.Common.WebClient
{
    public static class WebHttpClient
    {
        public static HttpClient webAPIClient = new HttpClient();
        static WebHttpClient()
        {
            webAPIClient.BaseAddress = new Uri("https://localhost:44355/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
