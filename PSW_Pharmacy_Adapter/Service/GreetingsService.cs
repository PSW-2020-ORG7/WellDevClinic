using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class GreetingsService : IGreetingsService
    {
        private readonly IApiKeyRepository _ApiKeyRepo;
        private readonly HttpClient _Client;

        public GreetingsService(MyDbContext dbContext, HttpClient client)
        {
            _ApiKeyRepo = new ApiKeyRepository(dbContext);
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
