using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class MedicationService : IMedicationService
    {
        private readonly IHttpClientFactory _clientFactory;
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";


        public MedicationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Medication>> GetAllMedication()
            => JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(communicationLink + "/api/drug"))
                           .Content.ReadAsStringAsync().Result);
    }
}
