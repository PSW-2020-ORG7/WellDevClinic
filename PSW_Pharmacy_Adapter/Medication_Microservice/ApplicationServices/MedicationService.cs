using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Mapping;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices
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


        public async Task<List<MedicationDto>> GetAllPharmacyMedications(string pharmacyName)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            _clientFactory.CreateClient().DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await _clientFactory.CreateClient().GetAsync(ph.Url + "getAllMedications/" + pharmacyName);
            return JsonConvert.DeserializeObject<List<MedicationDto>>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<MedicationDto> GetPharmacyMedication(string pharmacyName, string medName)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            _clientFactory.CreateClient().DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await _clientFactory.CreateClient().GetAsync(ph.Url + "checkAvailability/" + medName + "/" + pharmacyName);
            return JsonConvert.DeserializeObject<MedicationDto>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<List<MedicationDto>> GetPharmacyMedications(string pharmacyName, List<string> medicationNames)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            string jsonString = JsonConvert.SerializeObject(medicationNames);
            using (HttpContent content = new StringContent(jsonString))
            {
                try
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    _clientFactory.CreateClient().DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
                    var response = await _clientFactory.CreateClient().PostAsync(ph.Url + "checkAvailability/" + pharmacyName, content);
                    return JsonConvert.DeserializeObject<List<MedicationDto>>(response.Content.ReadAsStringAsync().Result);
                }
                catch
                {
                    Console.WriteLine("Connection can not be made!");
                    return null;
                }
            }
        }


        public async Task<List<PharmacyMedicationDto>> GetPharmacyByMedicationAsync(Medication med)
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
                }
            return pharmacies;
        }

        // TODO A: Srediti funkciju
        public async Task<List<PharmacyMedicationDto>> GetPharmacyByMedicationsAsync(List<Medication> medications)
        {
            List<PharmacyMedicationDto> pharmacies = new List<PharmacyMedicationDto>();
            var medNames = medications.Select(x => x.Name).ToList();
            foreach (Api ph in _keyRepo.GetAll())
            {
                List<MedicationDto> phMededications = await GetPharmacyMedications(ph.NameOfPharmacy, medNames);
                if (phMededications == null)
                    continue;
                if (!phMededications.Select(x => x.Amount).ToList().Exists(x => x <= 0)
                    && CompareMedicationsLists(MedicationMapper.MapMedicationList(phMededications), medications))
                    foreach (MedicationDto medicationDto in phMededications)
                        pharmacies.Add(new PharmacyMedicationDto(ph.NameOfPharmacy, MedicationMapper.MapMedication(medicationDto), medicationDto.Price));
            }
            return pharmacies;
        }

        public async Task<Medication> OrderMedicationAsync(string phName, string medName, int amount)
        {
            Api ph = _keyRepo.Get(phName);
            _clientFactory.CreateClient().DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await _clientFactory.CreateClient().GetAsync(ph.Url + "orderMedicine/" + phName + "?medicineName=" + medName + "&amount=" + amount);
            MedicationDto boughtMed = JsonConvert.DeserializeObject<MedicationDto>(response.Content.ReadAsStringAsync().Result);
            if (boughtMed != null)
                return await SaveToHospitalAsync(MedicationMapper.MapMedication(boughtMed));
            return null;
        }

        public async Task<List<Medication>> OrderMedicationsAsync(string phName, List<MedicationOrderDto> orders)
        {
            Api ph = _keyRepo.Get(phName);
            string jsonStringOrder = JsonConvert.SerializeObject(orders);
            using (HttpContent orderContent = new StringContent(jsonStringOrder))
            {
                orderContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                _clientFactory.CreateClient().DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
                var response = await _clientFactory.CreateClient().PostAsync(ph.Url + "orderMedicines/" + phName, orderContent);
                List<MedicationDto> boughtMed = JsonConvert.DeserializeObject<List<MedicationDto>>(response.Content.ReadAsStringAsync().Result);
                if (boughtMed.Count > 0)
                {
                    List<Medication> boughtMedications = new List<Medication>();
                    foreach (Medication medication in MedicationMapper.MapMedicationList(boughtMed))
                    {
                        Medication med = await SaveToHospitalAsync(medication);
                        if (med != null)
                            boughtMedications.Add(med);
                    }
                    return boughtMedications;
                }
            }
            return null;
        }

        public async Task<List<Medication>> GetUnsyncedMedicationsAsync(string pharmacyName)
        {
            List<Medication> phMeds = MedicationMapper.MapMedicationList(await GetAllPharmacyMedications(pharmacyName));
            return CheckIngredientsMatching(GetAllHospitalMedications().Result, phMeds);
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

        private async Task<Medication> SaveToHospitalAsync(Medication medication)
        {
            string jsonString = JsonConvert.SerializeObject(medication);
            using (HttpContent content = new StringContent(jsonString))
            {
                var response = await _clientFactory.CreateClient().PutAsync(Global.hospitalCommunicationLink + "/api/drug", content);
                return JsonConvert.DeserializeObject<Medication>(response.Content.ReadAsStringAsync().Result);
            }
        }

        private bool CompareMedicationsStructure(Medication medication1, Medication medication2)
        {
            var ingredientList1 = medication1.Ingredients.Select(x => x.Name.ToLower()).ToList();
            var ingredientList2 = medication2.Ingredients.Select(x => x.Name.ToLower()).ToList();
            if (ingredientList1.All(ingredientList2.Contains))
                return true;
            return false;
        }

        private bool CompareMedicationsLists(List<Medication> medicationList1, List<Medication> medicationList2)
        {
            var list1 = medicationList1.Select(x => x.Name.ToLower()).ToList();
            var list2 = medicationList2.Select(x => x.Name.ToLower()).ToList();
            if (list1.All(list2.Contains))
                return true;
            return false;
        }
    }
}
