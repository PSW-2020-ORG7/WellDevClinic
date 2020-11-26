using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PSW_Pharmacy_Adapter.Controllers;
using Moq;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Model;
using Shouldly;
using PSW_Pharmacy_Adapter.Adapter;

namespace PSW_Pharmacy_Adapter.UnitTests
{
    public class ManipulatePharmacyAPITest
    {
        [Fact]
        public void Get_Selected_Pharmacy()
        {
            var StubRepository = new Mock<IAPIKeyRepository>();
            var pharmacies = CreatePharmacyAPIRepository(); 
            APIKeyController pc = new APIKeyController();

            Api a = pc.GetPharmacy("pharmacy1");

            a.ShouldBeEquivalentTo("api1");
        }


        public static List<Api> CreatePharmacyAPIRepository()
        {
            var pharmacies = new List<Api>();
            Api a1 = new Api("pharmacy1", "api1", "localhost:454545");
            Api a2 = new Api("pharmacy2", "api2", "localhost:5000");
            Api a3 = new Api("pharmacy3", "api3", "localhost:50007");
            Api a4 = new Api("pharmacy4", "api4", "localhost:8989");

            pharmacies.Add(a1);
            pharmacies.Add(a2);
            pharmacies.Add(a3);
            pharmacies.Add(a4);

            return pharmacies;
        }
    }
}
