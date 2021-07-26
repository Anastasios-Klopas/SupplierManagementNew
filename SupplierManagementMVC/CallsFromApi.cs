using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SupplierManagementMVC
{
    public static class CallsFromApi
    {
        public static HttpClient client = new HttpClient();
        static CallsFromApi()
        {
            client.BaseAddress = new Uri("https://localhost:44370/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}