using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Mapping;
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

        public async Task<List<MedicationDto>> GetAllPharmacyMedications(string pharmacyName) //TODO A: Napraviti na isi metodu
        {
            Api ph = _keyRepo.Get(pharmacyName);
            return JsonConvert.DeserializeObject<List<MedicationDto>>(
                           (await _clientFactory.CreateClient().GetAsync(ph.Url + "getAllMedications/" + pharmacyName))
                           .Content.ReadAsStringAsync().Result);
        }

        public async Task<MedicationDto> GetPharmacyMedication(string pharmacyName, string medName) //TODO A: Napraviti na isi metodu
        {
            Api ph = _keyRepo.Get(pharmacyName);
            var response = (await _clientFactory.CreateClient().GetAsync(ph.Url + "checkAvailability/" + medName + "/" + pharmacyName));
            return JsonConvert.DeserializeObject<MedicationDto>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<List<PharmacyMedicationDto>> GetPharmacyByMedicineAsync(Medication med)
        {
            List<PharmacyMedicationDto> pharmacies = new List<PharmacyMedicationDto>();
            foreach (Api ph in _keyRepo.GetAll())
                try
                {
                    MedicationDto phMed = await GetPharmacyMedication(ph.NameOfPharmacy, med.Name);
                    if (phMed != null)
                        pharmacies.Add(new PharmacyMedicationDto(ph.NameOfPharmacy, MedicationMapper.MapMedication(phMed), phMed.Price));
                }
                catch
                {
                    Console.WriteLine("Connection can not be made!");
                    continue;
                }
            return pharmacies;
        }

        public async Task<List<Medication>> GetUnsyncedMedicationsAsync(string pharmacyName)
        {
            List<Medication> phMeds = new List<Medication>();
            foreach (MedicationDto med in (await GetAllPharmacyMedications(pharmacyName)))
                phMeds.Add(MedicationMapper.MapMedication(med));
             return CheckIngredientsMatching(GetAllHospitalMedications().Result, phMeds);
        }

        private List<Medication> CheckIngredientsMatching(List<Medication> hospMeds, List<Medication> phMeds)
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
