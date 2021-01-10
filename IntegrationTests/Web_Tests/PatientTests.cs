using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Shouldly;

namespace IntegrationTests.Web_Tests
{
    public class PatientTests : IClassFixture<WebApplicationFactory<InterlayerController.Startup>>
    {
        private readonly WebApplicationFactory<InterlayerController.Startup> _factory;
        public PatientTests(WebApplicationFactory<InterlayerController.Startup> factory)
        {
            _factory = factory;
        }

        string communicationLink = "http://localhost:51393";

        [Theory]
        [MemberData(nameof(PatientData))]
        public async void Block_patient(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.PutAsync(communicationLink + "/api/patient/" + id.ToString(), null);
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Fact]
        public async void Get_blocked_patients()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/blocked_patients");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> PatientData =>
            new List<object[]>
            {
                new object[] {7,HttpStatusCode.OK}
            };
    }
}
