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
        private readonly IAPIKeyRepository _ApiKeyRepo;
        private readonly HttpClient _Client;

        public GreetingsService(IAPIKeyRepository apiKeyRepo, HttpClient client)
        {
            _ApiKeyRepo = apiKeyRepo;
            _Client = client;
        }

        public async Task<HttpResponseMessage> GreetPharmacy(string id)
        {
            Api a = _ApiKeyRepo.Get(id);

            _Client.DefaultRequestHeaders.Add("api-key", a.ApiKey);
            HttpResponseMessage response = await _Client.GetAsync(a.Url + "/greet");
            Console.WriteLine("Status: " + response.StatusCode.ToString());

            return response;
        }
    }
}
