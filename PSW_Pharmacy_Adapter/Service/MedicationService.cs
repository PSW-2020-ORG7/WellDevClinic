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

        public MedicationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Medication>> GetAllMedication()
            => JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug"))
                           .Content.ReadAsStringAsync().Result);
    }
}
