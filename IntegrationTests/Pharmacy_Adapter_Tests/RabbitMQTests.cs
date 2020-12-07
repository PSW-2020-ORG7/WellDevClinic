using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class RabbitMQTests
    {
        private ActionAndBenefitRepository actionRepository;
        public const int TEST_ID = 1111;
        public const int TEST_ID1 = 5555;
        public const string TEST_PHARMACY = "Benu";
        public const string TEST_MESSAGE = "Ponuda koju ne mozete propustiti!";
        public DateTime TEST_START = DateTime.Now;
        public DateTime TEST_END = DateTime.Now.AddDays(5);

        [Fact]
        public void Add_Message()
        {
            MyContextFactory cf = new MyContextFactory();
            actionRepository = new ActionAndBenefitRepository(cf.CreateDbContext(new string[0]));
            ActionAndBenefit ab = new ActionAndBenefit(TEST_ID, TEST_PHARMACY, TEST_MESSAGE, TEST_START, TEST_END, ActionStatus.pending);
            //Console.WriteLine(" [x] Received {0}", ab.PharmacyName);

            actionRepository.Save(ab);
            actionRepository.Delete(TEST_ID);       //rollback

            ab.ShouldNotBeNull();
        }


        [Fact]
        public void Check_Message()
        {
            MyContextFactory cf = new MyContextFactory();
            actionRepository = new ActionAndBenefitRepository(cf.CreateDbContext(new string[0]));
            ActionAndBenefit ab = new ActionAndBenefit(TEST_ID1, TEST_PHARMACY, TEST_MESSAGE, TEST_START, TEST_END, ActionStatus.pending);

            ab = actionRepository.Get(TEST_ID1);
            ab.ShouldBeNull();
        }
    }
}
