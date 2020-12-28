using Moq;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service;
using Shouldly;
using System.Collections.Generic;
using System.Net.Http;
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

            List<Medication> allGood = service.CheckIngredientsMatching(CreateMedicationList(), CreateMedicationList());

            allGood.ShouldBeNull();
        }

        [Fact]
        public void Compare_Different_Medicines_Ingredients()
        {
            var client = new Mock<IHttpClientFactory>();
            var keyRepo = new Mock<IApiKeyRepository>();
            MedicationService service = new MedicationService(client.Object, keyRepo.Object);

            List<Medication> notEqual = service.CheckIngredientsMatching(CreateMedicationList(), CreateAnotherMedicationList());

            notEqual.ShouldNotBeNull();
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
                new Ingredient(1, "O2", 10),
                new Ingredient(2, "H5", 10),
                new Ingredient(3, "M1", 10),
                new Ingredient(4, "L8", 10),
                new Ingredient(5, "K8", 10),
                new Ingredient(6, "U7", 10),
            };
    }
}
