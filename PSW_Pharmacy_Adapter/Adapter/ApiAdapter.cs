using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Adapter
{
    public class ApiAdapter
    {
        public ApiAdapter() { }

        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:4200");
            var request = new RestRequest("/api");
            var response = client.Get<List<Model.Api>>(request);
            //Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<Model.Api> result = response.Data;
            result.ForEach(api => Console.WriteLine(api.ApiKey));
        }
    }
}
