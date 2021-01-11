using System.Net.Http;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices
{
    public class GreetingsService : IGreetingsService
    {
        private readonly IApiKeyRepository _apiKeyRepo;
        private readonly IHttpClientFactory _clientFactory;

        public GreetingsService(IApiKeyRepository apiKeyRepo, IHttpClientFactory clientFactory)
        {
            _apiKeyRepo = apiKeyRepo;
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> GreetPharmacy(string id)
        {
            Api a = _apiKeyRepo.Get(id);

            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("api-key", a.ApiKey);
            return await client.GetAsync(a.Url + "/greet");
        }
    }
}
