using Xunit;
using Shouldly;
using PSW_Pharmacy_Adapter;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class ApiManipulationTests
    {
        public const string TEST_NAME = "TestPharmacyName";
        public const string TEST_API = "0bs2-2s2c-78ar-qwer";
        public const string TEST_URL = "www.pharmacy.com";
        public const int TEST_GRPC = 2222;

        [Fact]
        public void Add_New_Pharmacy_ApiInfo()
        {
            MyContextFactory cf = new MyContextFactory();
            ApiKeyService service = new ApiKeyService(new ApiKeyRepository(cf.CreateDbContext(new string[0])));

            Api added = service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_GRPC,TEST_URL));
            service.DeletePharmacy(TEST_NAME);  //rollback

            added.ShouldNotBeNull();
        }

        [Fact]
        public void Add_Exisitng_Pharmacy_ApiInfo()
        {
            MyContextFactory cf = new MyContextFactory();
            ApiKeyService service = new ApiKeyService(new ApiKeyRepository(cf.CreateDbContext(new string[0])));
            service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_GRPC,TEST_URL));

            Api added = service.AddPharmacy(new Api(TEST_NAME, TEST_API, TEST_GRPC,TEST_URL));
            service.DeletePharmacy(TEST_NAME);  //rollback

            added.ShouldBeNull();
        }
    }
}
