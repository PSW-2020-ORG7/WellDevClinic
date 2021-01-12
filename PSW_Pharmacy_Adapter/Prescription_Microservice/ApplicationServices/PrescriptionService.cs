using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices
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
                             (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/prescription/all"))
                             .Content.ReadAsStringAsync().Result);

        public async Task<Prescription> GetPrescription(long id)
            => JsonConvert.DeserializeObject<Prescription>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/prescription/" + id))
                           .Content.ReadAsStringAsync().Result);


    }
}
