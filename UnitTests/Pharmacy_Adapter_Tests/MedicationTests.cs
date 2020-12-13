using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Moq;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service;
using Shouldly;
using Xunit;

namespace UnitTests.Pharmacy_Adapter_Tests
{
    public class MedicationTests
    {
        [Fact]
        public void Compare_Equal_Medicines_Ingredients()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            bool equal = service.SyncMedicationIngredients(CreateMedicationList(), CreateMedicationList());

            equal.ShouldBeTrue();
        }

        [Fact]
        public void Compare_Different_Medicines_Ingredients()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            bool notEqual = service.SyncMedicationIngredients(CreateMedicationList(), CreateAnotherMedicationList());

            notEqual.ShouldBeFalse();
        }

        public List<Medication> CreateMedicationList()
        {
            List<Ingredient> ing = GetIngredients();
            return new List<Medication>()
                    {
                        new Medication(1, "Brufen", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[2]}, null),
                        new Medication(2, "Aspirin", 10, true, new List<Ingredient>(){ ing[3], ing[4], ing[5]}, null),
                        new Medication(3, "Bromazepam", 10, true, new List<Ingredient>(){ ing[5], ing[1], ing[2]}, null),
                        new Medication(4, "Paracetamol", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[5]}, null),
                    };
        }

        public List<Medication> CreateAnotherMedicationList()
        {
            List<Ingredient> ing = GetIngredients();
            return new List<Medication>()
                    {
                        new Medication(2, "Aspirin", 10, true, new List<Ingredient>(){ing[4], ing[5]}, null),
                        new Medication(3, "Bromazepam", 10, true, new List<Ingredient>(){ ing[5], ing[1], ing[2]}, null),
                        new Medication(4, "Paracetamol", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[5]}, null),
                    };
        }

        public List<Ingredient> GetIngredients()
            => new List<Ingredient>()
            {
                new Ingredient("O2", 10),
                new Ingredient("H5", 10),
                new Ingredient("M1", 10),
                new Ingredient("L8", 10),
                new Ingredient("K8", 10),
                new Ingredient("U7", 10),
            };
    }
}
