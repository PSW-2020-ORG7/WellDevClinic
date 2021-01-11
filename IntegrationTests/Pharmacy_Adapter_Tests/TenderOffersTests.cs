using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository;
using Shouldly;
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
            TenderOffer offer = new TenderOffer(TEST_ID, TEST_PHARMACY_NAME, null, TEST_PRICE, TEST_MESSAGE, TEST_TENDER_ID, "proba");

            tenderRepository.Save(offer);
            tenderRepository.Delete(TEST_ID);       //rollback

            offer.ShouldNotBeNull();
        }

    }
}
