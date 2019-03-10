using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebAPIMVC
{
    public static class GlobalClass
    {
        public static HttpClient WebClient = new HttpClient();
        static GlobalClass()
        {
            WebClient.BaseAddress = new Uri("http://localhost:55401/api/");
            WebClient.DefaultRequestHeaders.Clear();
            WebClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}