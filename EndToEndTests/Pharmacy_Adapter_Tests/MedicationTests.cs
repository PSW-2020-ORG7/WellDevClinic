using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class MedicationTests
    {
        public const string TEST_AVAILABLE_MEDICATION = "Brufen";
        public const string TEST_AVAILABLE_PHARMACY = "Jankovic";
        public const string TEST_UNAVAILABLE_MEDICATION = "medic";
        public const string TEST_UNAVAILABLE_PHARMACY = "PH5896";

        [Fact]
        public async void Is_Medications_Available()
        {
            GrpcClientService service = new GrpcClientService();

            List<Medication> availableMeds = await service.GetAllMedicationsAmount(TEST_AVAILABLE_PHARMACY);

            availableMeds.ShouldNotBeNull();
        }

        [Fact]
        public async void Is_Medications_Unavailable()
        {
            GrpcClientService service = new GrpcClientService();

            List<Medication> unavailableMeds = await service.GetAllMedicationsAmount(TEST_UNAVAILABLE_MEDICATION);

            unavailableMeds.ShouldBeNull();
        }


        [Fact]
        public async void Is_Medication_Available()
        {
            GrpcClientService service = new GrpcClientService();

            int availableMed = await service.GetMedicationAmount(TEST_AVAILABLE_MEDICATION, TEST_AVAILABLE_PHARMACY);

            availableMed.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async void Is_Medication_Unavailable()
        {
            GrpcClientService service = new GrpcClientService();

            int availableMed = await service.GetMedicationAmount(TEST_UNAVAILABLE_MEDICATION, TEST_UNAVAILABLE_PHARMACY);

            availableMed.ShouldBeLessThan(0);
        }
    }
}
