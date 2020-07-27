using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList_Android.Data
{
    public class RestService
    {
        private static readonly string API_URL = "http://192.168.0.2";

        private static RestService _singleton;
        private HttpClient _client;
        private Action<HelloModel> _responseHandler;

        public static void Init(Action<HelloModel> responseHandler)
        {
            _singleton = new RestService(responseHandler);
        }

        public RestService(Action<HelloModel> responseHandler)
        {
            _client = new HttpClient();
            _responseHandler = responseHandler;
        }

        public static async void GetHello()
        {
            Uri uri = new Uri(API_URL/*+"/helloWorld"*/);

            HttpResponseMessage response = await _singleton._client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                HelloModel model = new HelloModel() { };

                _singleton._responseHandler(model);
            }
            else
            {
                _singleton._responseHandler(null);
            }
        }
    }
}