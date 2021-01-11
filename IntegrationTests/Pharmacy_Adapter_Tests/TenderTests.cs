using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository;
using Shouldly;
using System;
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
            Tender ten = new Tender(TEST_ID, null, TEST_START, TEST_END, TEST_OFFER_WINNER, TEST_DELETED);

            tenderRepository.Save(ten);
            tenderRepository.Delete(TEST_ID);       //rollback
            
            ten.ShouldNotBeNull();
        }

    }
}
