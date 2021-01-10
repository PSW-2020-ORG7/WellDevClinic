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
    public class TenderOffersTests
    {
        public const int TEST_ID = 11111111;
        public const string TEST_PHARMACY_NAME = "Apoteka123456789";
        public double TEST_PRICE = 10000;
        public string TEST_MESSAGE = "say hi";
        public long TEST_TENDER_ID = 12300000000;

        [Fact]
        public void Add_Tender_Offer_Successfully()
        {
            MyContextFactory cf = new MyContextFactory();
            TenderOfferRepository tenderRepository = new TenderOfferRepository(cf.CreateDbContext(new string[0]));
            TenderOffer offer = new TenderOffer(TEST_ID, TEST_PHARMACY_NAME, CreateMedicationList(), TEST_PRICE, TEST_MESSAGE, TEST_TENDER_ID, "proba");

            tenderRepository.Save(offer);
            tenderRepository.Delete(TEST_ID);       //rollback

            offer.ShouldNotBeNull();
        }





        public List<Medication> CreateMedicationList()
        {
            List<Ingredient> ing = GetIngredients();
            return new List<Medication>()
                    {
                        new Medication(1000, "Brufen", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[2]}, null),
                        new Medication(2000, "Aspirin", 10, true, new List<Ingredient>(){ ing[3], ing[4], ing[5]}, null),
                        new Medication(3000, "Bromazepam", 10, true, new List<Ingredient>(){ ing[5], ing[1], ing[2]}, null),
                        new Medication(4000, "Paracetamol", 10, true, new List<Ingredient>(){ ing[0], ing[1], ing[5]}, null),
                    };
        }

        public List<Ingredient> GetIngredients()
            => new List<Ingredient>()
            {
                new Ingredient(1000, "O2", 10),
                new Ingredient(2000, "H5", 10),
                new Ingredient(3000, "M1", 10),
                new Ingredient(4000, "L8", 10),
                new Ingredient(5000, "K8", 10),
                new Ingredient(6000, "U7", 10),
            };


    }
}
