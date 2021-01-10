using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using PSW_Web_app;
using InterlayerController;
using System.Net.Http;
using System.Net;
using Shouldly;
using WellDevCore.Model.dtos;
using Newtonsoft.Json;

namespace IntegrationTests.Web_Tests
{
    public class LoginTests : IClassFixture<WebApplicationFactory<InterlayerController.Startup>>
    {
        private readonly WebApplicationFactory<InterlayerController.Startup> _factory;

        public LoginTests(WebApplicationFactory<InterlayerController.Startup> factory)
        {
            _factory = factory;
        }

        string communicationLink = "http://localhost:51393";


        /*[Theory]
        [MemberData(nameof(loginData))]
        public async void login(UserDTO user, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            String request = communicationLink + "/api/user/login";
            StringContent bodyContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(request, bodyContent);
            var value = await response.Content.ReadAsStringAsync();
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        public static IEnumerable<object[]> loginData =>
            new List<object[]>
            {
                new object[] {new UserDTO("username","password"),HttpStatusCode.OK}
            };*/
    }
}
