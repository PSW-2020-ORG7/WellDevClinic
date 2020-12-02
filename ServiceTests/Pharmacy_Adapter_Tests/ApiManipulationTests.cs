using Moq;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using PSW_Pharmacy_Adapter;
using Microsoft.EntityFrameworkCore;
using PSW_Pharmacy_Adapter.Repository;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class ApiManipulationTests
    {
        public const string TEST_NAME = "TestPharmacyName";
        public const string TEST_API = "0bs2-2s2c-78ar-qwer";
        public const string TEST_URL = "www.pharmacy.com";

        [Fact]
        public void Add_New_Pharmacy_ApiInfo()
        {
            MyContextFactory cf = new MyContextFactory();
            ApiKeyService service = new ApiKeyService(cf.CreateDbContext(new string[0]));

            Api added = service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_URL));
            service.DeletePharmacy(TEST_NAME);  //rollback

            added.ShouldNotBeNull();
        }

        [Fact]
        public void Add_Exisitng_Pharmacy_ApiInfo()
        {
            MyContextFactory cf = new MyContextFactory();
            ApiKeyService service = new ApiKeyService(cf.CreateDbContext(new string[0]));
            service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_URL));

            Api added = service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_URL));
            service.DeletePharmacy(TEST_NAME);  //rollback

            added.ShouldBeNull();
        }
    }
}
