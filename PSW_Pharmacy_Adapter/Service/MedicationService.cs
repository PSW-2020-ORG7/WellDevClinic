using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
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
        private readonly IHttpClientFactory _clientFactory;
        private readonly IApiKeyRepository _keyRepo;

        public MedicationService(IHttpClientFactory clientFactory, IApiKeyRepository keyRepo)
        {
            _clientFactory = clientFactory;
            _keyRepo = keyRepo;
        }

        public async Task<List<Medication>> GetAllHospitalMedications()
            => JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug"))
                           .Content.ReadAsStringAsync().Result);

        public async Task<Medication> GetHospitalMedication(long id)
        => JsonConvert.DeserializeObject<Medication>(
                       (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug/" + id))
                       .Content.ReadAsStringAsync().Result);

        public async Task<List<Medication>> GetAllPharmacyMedications(string pharmacyName) //TODO A: Napraviti na isi metodu
        {
            Api ph = _keyRepo.Get(pharmacyName);
            return JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(ph.Url + "/api/drug/all"))
                           .Content.ReadAsStringAsync().Result);
        }

        public async Task<Medication> GetPharmacyMedication(string pharmacyName, long medId) //TODO A: Napraviti na isi metodu
        {
            Api ph = _keyRepo.Get(pharmacyName);
            return JsonConvert.DeserializeObject<Medication>(
                           (await _clientFactory.CreateClient().GetAsync(ph.Url + "/api/drug/" + medId))
                           .Content.ReadAsStringAsync().Result);
        }

        public List<Medication> GetUnsyncedMedications(string pharmacyName)
            => CheckIngredientsMatching(GetAllHospitalMedications().Result, GetAllPharmacyMedications(pharmacyName).Result);

        public async Task<List<string>> GetPharmacyByMedicineAsync(Medication med)
        {
            List<string> pharmacies = new List<string>();
            foreach (Api ph in _keyRepo.GetAll())
                try
                {
                    if ((await GetPharmacyMedication(ph.NameOfPharmacy, med.Id)) != null)
                        pharmacies.Add(ph.NameOfPharmacy);
                }
                catch
                {
                    Console.WriteLine("Connection can not be made!");
                    continue;
                }
            return pharmacies;
        }

        public List<Medication> CheckIngredientsMatching(List<Medication> hospMeds, List<Medication> phMeds)
        {
            List<Medication> changedMeds = new List<Medication>();
            foreach (Medication phMed in phMeds)
            {
                if (!CompareMedicationsStructure(hospMeds.Find(x => x.Id == phMed.Id), phMed))
                    changedMeds.Add(phMed);
            }
            if (changedMeds.Count == 0)
                return null;
            return changedMeds;
        }

        private bool CompareMedicationsStructure(Medication hospM, Medication phM)
        {
            var hospList = hospM.Ingredients.Select(x => x.Name).ToList();
            var phList = phM.Ingredients.Select(x => x.Name).ToList();
            if (!hospList.All(phList.Contains))
                return false;
            else
                return true;
        }
    }
}
