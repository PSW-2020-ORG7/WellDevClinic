using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.Pharmacy_Adapter_Tests
{
    public class MedicationTests
    {
        public const string AVAILABLE_MEDICATION = "Brufen";
        public const string TEST_PHARMACY = "Jankovic";
        public const string UNAVAILABLE_MEDICATION = "medic";


        [Fact]
        public void Get_Pharmacy_Medication_Stock()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            keyRepo.Setup(x => x.Get(TEST_PHARMACY)).Returns(CreateTestApi());

            HttpClient client = MockClient(CreateReturnList());
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            MedicationService service = new MedicationService(mockFactory.Object, keyRepo.Object);

            Task<List<MedicationDto>> pharmacyMedication = service.GetAllPharmacyMedications(TEST_PHARMACY);

            pharmacyMedication.Result.ShouldNotBeNull();
        }

        [Fact]
        public void Check_Available_Medicaiton()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            keyRepo.Setup(x => x.Get(TEST_PHARMACY)).Returns(CreateTestApi());
            HttpClient client = MockClient2(new MedicationDto(AVAILABLE_MEDICATION, 1L, 85));
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            MedicationService service = new MedicationService(mockFactory.Object, keyRepo.Object);

            Task<MedicationDto> medicationDtos = service.GetPharmacyMedication(TEST_PHARMACY, AVAILABLE_MEDICATION);

            medicationDtos.Result.ShouldNotBeNull();
        }

        [Fact]
        public void Check_Unavailable_Medicaiton()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            keyRepo.Setup(x => x.Get(TEST_PHARMACY)).Returns(CreateTestApi());
            HttpClient client = MockClient(null);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            MedicationService service = new MedicationService(mockFactory.Object, keyRepo.Object);

            Task<MedicationDto> unavailableMedicine = service.GetPharmacyMedication(TEST_PHARMACY, UNAVAILABLE_MEDICATION);

            unavailableMedicine.Result.ShouldBeNull();
        }

        [Fact]
        public void Get_Multiple_Pharmacy_Medications()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            keyRepo.Setup(x => x.Get(TEST_PHARMACY)).Returns(CreateTestApi());

            HttpClient client = MockClient(CreateReturnList());
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            MedicationService service = new MedicationService(mockFactory.Object, keyRepo.Object);

            Task<List<MedicationDto>> medications = service.GetPharmacyMedications(TEST_PHARMACY, CreateMedicationList());

            medications.Result.ShouldNotBeNull();
        }

        [Fact]
        public void Get_Empty_Pharmacy_MedicationList()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            keyRepo.Setup(x => x.Get(TEST_PHARMACY)).Returns(CreateTestApi());

            HttpClient client = MockClient(null);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            MedicationService service = new MedicationService(mockFactory.Object, keyRepo.Object);

            Task<List<MedicationDto>> medicationDtos = service.GetPharmacyMedications(TEST_PHARMACY, CreateMedicationList());

            medicationDtos.Result.ShouldBeNull();
        }

        public List<string> CreateMedicationList() 
            => new List<string>
            {
                "Brufen",
                "Aspirin"
            };

        public List<MedicationDto> CreateReturnList()
            => new List<MedicationDto>
            {
                new MedicationDto("Med1", 1L, 10),
                new MedicationDto("Med2", 2L, 12),
                new MedicationDto("Med3", 3L, 8),
                new MedicationDto("Med4", 4L, 25)
            };

        public HttpClient MockClient(List<MedicationDto> medicationsToReturn)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(medicationsToReturn)),
                });
            return new HttpClient(mockHttpMessageHandler.Object);
        }

        public HttpClient MockClient2(MedicationDto medicationsToReturn)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(medicationsToReturn)),
                });
            return new HttpClient(mockHttpMessageHandler.Object);
        }

        public Api CreateTestApi()
            => new Api(TEST_PHARMACY, "12345", 2222,"http://localhost:8081/Jankovic");
    }
}
