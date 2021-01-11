using Moq;
using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service;
using Shouldly;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.Pharmacy_Adapter_Tests
{
    public class MedicationTests
    {
        public const string TEST_AVAILABLE_MEDICATION = "Brufen";
        public const string TEST_AVAILABLE_PHARMACY = "Jankovic";
        public const string TEST_UNAVAILABLE_MEDICATION = "medic";
        public const string TEST_UNAVAILABLE_PHARMACY = "PH5896";


        [Fact]
        public void Check_Availability()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            Task<List<MedicationDto>> medicationDtos = service.GetAllPharmacyMedications(TEST_AVAILABLE_PHARMACY);
            medicationDtos.ShouldNotBeNull();
        }

        [Fact]
        public void Order_Medicine()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            Task<MedicationDto> medicationDtos = service.GetPharmacyMedication(TEST_UNAVAILABLE_PHARMACY, TEST_AVAILABLE_MEDICATION);
            medicationDtos.ShouldNotBeNull();
        }

        [Fact]
        public void Order_Medicines()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            Task<List<MedicationDto>> medicationDtos = service.GetPharmacyMedications(TEST_UNAVAILABLE_PHARMACY, CreateMedicationList());
            medicationDtos.ShouldNotBeNull();
        }

        [Fact]
        public void Get_All__Medicines()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            Task<List<MedicationDto>> medicationDtos = service.GetAllPharmacyMedications(TEST_UNAVAILABLE_PHARMACY);
            medicationDtos.ShouldNotBeNull();
        }

        public List<string> CreateMedicationList() 
        {
            List<string> medicationNameList = new List<string>();
            medicationNameList.Add("Brufen");
            medicationNameList.Add("Aspirin");

            return medicationNameList;
        }
    }
}
