using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList_Android.Data
{
    public class RestService
    {
        private static readonly string API_URL = "https://localhost:44316/api";

        private static RestService _singleton;
        private HttpClient client;

        public void Init()
        {
            _singleton = new RestService();
        }

        public RestService()
        {
            client = new HttpClient();
        }

        public static async Task<HelloModel> GetHello()
        {
            Uri uri = new Uri(API_URL+"/helloWorld");

            HttpResponseMessage response = await _singleton.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //HelloModel model = new HelloModel() {}

                return new HelloModel();
            }
            else
                return null;
        }
    }
}