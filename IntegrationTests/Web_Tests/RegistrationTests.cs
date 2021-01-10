using Microsoft.AspNetCore.Mvc.Testing;
using PSW_Web_app;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.Web_Tests
{
    public class RegistrationTests : IClassFixture<WebApplicationFactory<InterlayerController.Startup>>
    {
        private readonly WebApplicationFactory<InterlayerController.Startup> _factory;
        public RegistrationTests(WebApplicationFactory<InterlayerController.Startup> factory)
        {
            _factory = factory;
        }

        private readonly string communicationLink = "http://localhost:51393";

        [Theory]
        [MemberData(nameof(DoctorType))]
        public async void Get_all_doctors_for_type(string speciality, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/" + speciality);
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Fact]
        public async void Get_all_speciality()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/speciality/");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        public static IEnumerable<object[]> DoctorType =>
            new List<object[]>
            {
                new object[] {"Ortopedija",HttpStatusCode.OK},
                new object[] {"Interna medicina",HttpStatusCode.OK}
            };


    }
}
