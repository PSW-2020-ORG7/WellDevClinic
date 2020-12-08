using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class MedicationService : IMedicationService
    {
        private readonly HttpClient client;
        public MedicationService()
        {
            client = new HttpClient();
        }

        public async Task<List<Medication>> GetAllMedication()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/drug");
            string responseBody = response.Content.ReadAsStringAsync().Result;
            List<Medication> meds = JsonConvert.DeserializeObject<List<Medication>>(responseBody);
            return meds;

        }

    }
}
