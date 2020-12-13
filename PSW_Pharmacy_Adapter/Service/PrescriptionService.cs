using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PrescriptionService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Prescription>> GetAllPrescriptions()
            => JsonConvert.DeserializeObject<List<Prescription>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/prescription"))
                           .Content.ReadAsStringAsync().Result);
    }
}
