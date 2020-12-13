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

        public async Task<List<Medication>> GetAllMedication()
            => JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(Global.hospitalCommunicationLink + "/api/drug"))
                           .Content.ReadAsStringAsync().Result);

        public async Task<List<Medication>> GetPharmacyMedications(string pharmacyName)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            return JsonConvert.DeserializeObject<List<Medication>>(
                           (await _clientFactory.CreateClient().GetAsync(ph.Url + "/drug/all"))
                           .Content.ReadAsStringAsync().Result);
        }

        public bool SyncMedicationIngredients(List<Medication> hospMeds, List<Medication> phMeds)
        {
            foreach(Medication phMed in phMeds)
            {
                if (!CompareMedications(hospMeds.Find(x => x.Id == phMed.Id), phMed))
                    return false;
            }
            return true;
        }

        private bool CompareMedications(Medication hospM, Medication phM)
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
