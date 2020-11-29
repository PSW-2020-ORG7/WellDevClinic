using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class GreetingsService
    {
        private readonly IAPIKeyRepository ApiKeyRepo;

        public GreetingsService(APIKeyRepository keyRepo)
        {
            ApiKeyRepo = keyRepo;
        }

        public async Task<HttpResponseMessage> GreetPharmacy(string id)
        {
            Api a = ApiKeyRepo.Get(id);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", a.ApiKey);
            HttpResponseMessage response = await client.GetAsync(a.Url + "/greet");
            Console.WriteLine("Status: " + response.StatusCode.ToString());

            return response;
        }
    }
}
