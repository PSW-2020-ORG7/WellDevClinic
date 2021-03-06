﻿using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Mapping;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices
{
    public class PharmacyMedicationService : IPharmacyMedicationService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHospitalMedicationService _hospitalService;
        private readonly IApiKeyRepository _keyRepo;

        public PharmacyMedicationService(IHttpClientFactory clientFactory, IHospitalMedicationService hospitalService,IApiKeyRepository keyRepo)
        {
            _clientFactory = clientFactory;
            _hospitalService = hospitalService;
            _keyRepo = keyRepo;
        }

        public async Task<List<MedicationDto>> GetAllPharmacyMedications(string pharmacyName)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await client.GetAsync(ph.Url.Url + "getAllMedicines/" + pharmacyName);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return null;
            return JsonConvert.DeserializeObject<List<MedicationDto>>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<MedicationDto> GetPharmacyMedication(string pharmacyName, string medName)
        {
            Api ph = _keyRepo.Get(pharmacyName);
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await client.GetAsync(ph.Url.Url + "checkAvailability/" + medName + "/" + pharmacyName);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return null;
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
                    HttpClient client = _clientFactory.CreateClient();
                    client.DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
                    var response = await client.PostAsync(ph.Url.Url + "checkAvailability/" + pharmacyName, content);
                    if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                        return null;
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
            bool responded = false;
            foreach (Api ph in _keyRepo.GetAll())
                try
                {
                    MedicationDto phMed = await GetPharmacyMedication(ph.NameOfPharmacy, med.Name);
                    if (phMed != null)
                        pharmacies.Add(new PharmacyMedicationDto(ph.NameOfPharmacy, MedicationMapper.MapMedication(phMed), phMed.Price));
                    responded = true;
                }
                catch
                {
                    Console.WriteLine("Connection can not be made!");
                }
            if (!responded)
                return null;        // Throw exception? (408 or 504)
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
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
            var response = await client.GetAsync(ph.Url.Url + "orderMedicine/" + phName + "?medicineName=" + medName + "&amount=" + amount);
            MedicationDto boughtMed = JsonConvert.DeserializeObject<MedicationDto>(response.Content.ReadAsStringAsync().Result);
            if (boughtMed != null)
                return await _hospitalService.SaveToHospitalAsync(MedicationMapper.MapMedication(boughtMed));
            return null;
        }

        public async Task<List<Medication>> OrderMedicationsAsync(string phName, List<MedicationOrderDto> orders)
        {
            Api ph = _keyRepo.Get(phName);
            string jsonStringOrder = JsonConvert.SerializeObject(orders);
            using (HttpContent orderContent = new StringContent(jsonStringOrder))
            {
                orderContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpClient client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("apiKey", ph.ApiKey);
                var response = await client.PostAsync(ph.Url.Url + "orderMedicines/" + phName, orderContent);
                List<MedicationDto> boughtMed = JsonConvert.DeserializeObject<List<MedicationDto>>(response.Content.ReadAsStringAsync().Result);
                if (boughtMed.Count > 0)
                {
                    List<Medication> boughtMedications = new List<Medication>();
                    foreach (Medication medication in MedicationMapper.MapMedicationList(boughtMed))
                    {
                        Medication med = await _hospitalService.SaveToHospitalAsync(medication);
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
            return CheckIngredientsMatching(_hospitalService.GetAllHospitalMedications().Result, phMeds);
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
