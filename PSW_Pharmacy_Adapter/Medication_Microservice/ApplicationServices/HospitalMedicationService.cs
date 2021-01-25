using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Mapping;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices
{
    public class HospitalMedicationService : IHospitalMedicationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HospitalMedicationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Medication>> GetAllHospitalMedications()
            => JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug/medicationStock"))
                           .Content.ReadAsStringAsync().Result);

        public async Task<Medication> GetHospitalMedication(long id)
            => JsonConvert.DeserializeObject<Medication>(
                       (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug/" + id))
                       .Content.ReadAsStringAsync().Result);

        public async Task<Medication> SaveToHospitalAsync(Medication medication)
        {
            HttpResponseMessage response;
            var foundMedicine = await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug/getByName/" + medication.Name);
            if (!foundMedicine.StatusCode.Equals(HttpStatusCode.NoContent))
            {
                Medication medDb = JsonConvert.DeserializeObject<Medication>(foundMedicine.Content.ReadAsStringAsync().Result);
                medDb.Amount += medication.Amount;
                response = await UpdateMediaction(medDb);
            }
            else
            {
                response = await SaveMedicationAsync(medication);
            }
            return JsonConvert.DeserializeObject<Medication>(response.Content.ReadAsStringAsync().Result);
        }

        private async Task<HttpResponseMessage> UpdateMediaction(Medication medication)
        {
            string jsonString = JsonConvert.SerializeObject(medication);
            HttpContent content = new StringContent(jsonString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await _clientFactory.CreateClient().PutAsync(Global.hospitalCommunicationLink + "/api/drug/update", content);
        }

        private async Task<HttpResponseMessage> SaveMedicationAsync(Medication medication)
        {
            string jsonString = JsonConvert.SerializeObject(medication);
            HttpContent content = new StringContent(jsonString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await _clientFactory.CreateClient().PutAsync(Global.hospitalCommunicationLink + "/api/drug", content);
        }

        
    }
}
