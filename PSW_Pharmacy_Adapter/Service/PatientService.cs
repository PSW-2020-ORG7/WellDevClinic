using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class PatientService:IPatientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PatientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Patient>> GetAllPatients()
        => JsonConvert.DeserializeObject<List<Patient>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/patient"))
                           .Content.ReadAsStringAsync().Result);
    }
}
