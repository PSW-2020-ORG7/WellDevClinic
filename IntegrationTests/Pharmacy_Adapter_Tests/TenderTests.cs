using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class TenderTests
    {
        public const int TEST_ID = 11111111;
        public DateTime TEST_START = DateTime.Now;
        public DateTime TEST_END = DateTime.Now.AddDays(5);
        public long TEST_OFFER_WINNER = 0;
        public bool TEST_DELETED = false;

        [Fact]
        public void Add_Tender_Successfully()
        {
            MyContextFactory cf = new MyContextFactory();
            TenderRepository tenderRepository = new TenderRepository(cf.CreateDbContext(new string[0]));
            Tender ten = new Tender(TEST_ID, CreateMedicationList(), TEST_START, TEST_END, TEST_OFFER_WINNER, TEST_DELETED);

            tenderRepository.Save(ten);
            tenderRepository.Delete(TEST_ID);       //rollback
            
            ten.ShouldNotBeNull();
        }





        public List<Medication> CreateMedicationList()
        {
            List<Ingredient> ing = GetIngredients();
            return new List<Medication>()
                    {
                        new Medication(1001, "Brufen", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[2]}, null),
                        new Medication(2001, "Aspirin", 10, true, new List<Ingredient>(){ ing[3], ing[4], ing[5]}, null),
                        new Medication(3001, "Bromazepam", 10, true, new List<Ingredient>(){ ing[5], ing[1], ing[2]}, null),
                        new Medication(4001, "Paracetamol", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[5]}, null),
                    };
        }

        public List<Ingredient> GetIngredients()
            => new List<Ingredient>()
            {
                new Ingredient(1001, "O2", 10),
                new Ingredient(2001, "H5", 10),
                new Ingredient(3001, "M1", 10),
                new Ingredient(4001, "L8", 10),
                new Ingredient(5001, "K8", 10),
                new Ingredient(6001, "U7", 10),
            };


    }
}
