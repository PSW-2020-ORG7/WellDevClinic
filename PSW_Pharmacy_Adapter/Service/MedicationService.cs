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
    public class MedicationService 
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<List<Medication>> GetAllMedication()
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:44375/api/drug");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Medication> medications = JsonConvert.DeserializeObject<List<Medication>>(responseBody);
            medications.ForEach(medication => Console.WriteLine(medication.ToString()));
            return medications;
        }

    }
}
