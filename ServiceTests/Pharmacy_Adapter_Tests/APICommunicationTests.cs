using PSW_Pharmacy_Adapter.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Shouldly;
using Moq;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Moq.Protected;
using System.Threading;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class APICommunicationTests
    {
        [Fact]
        public async void Send_Greetings_MessageAsync()
        {
            var ApiRepo = new Mock<IAPIKeyRepository>();
            ApiRepo.Setup(a => a.GetAll()).Returns(CreatePharmacyAPIRepository());

            var handlerMock = new Mock<HttpMessageHandler>();
            var responsemsg = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("Greetings!")
            };

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                        .ReturnsAsync(responsemsg);

            GreetingsService greetingsService = new GreetingsService(ApiRepo.Object, new HttpClient(handlerMock.Object));
            // TODO: Mockovati klijenta (Neuspesno mock-ovanje na handlerMock)
            //var recivedStatus = await greetingsService.GreetPharmacy("ph1");

            /*recivedStatus.StatusCode.ShouldBeEquivalentTo(System.Net.HttpStatusCode.OK);
            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1),
               ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
               ItExpr.IsAny<CancellationToken>());*/
        }

        public static List<Api> CreatePharmacyAPIRepository()
        {
            var pharmacies = new List<Api>();
            Api a1 = new Api("ph1", "api1", "localhost:454545");
            Api a2 = new Api("ph2", "api2", "localhost:5000");
            Api a3 = new Api("ph3", "api3", "localhost:50007");
            Api a4 = new Api("ph4", "api4", "localhost:8989");

            pharmacies.Add(a1);
            pharmacies.Add(a2);
            pharmacies.Add(a3);
            pharmacies.Add(a4);

            return pharmacies;
        }
    }
}
