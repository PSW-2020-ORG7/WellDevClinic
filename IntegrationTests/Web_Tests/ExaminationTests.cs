using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTests.Web_Tests
{
    public class ExaminationTests : IClassFixture<WebApplicationFactory<InterlayerController.Startup>>
    {
        private readonly WebApplicationFactory<InterlayerController.Startup> _factory;
        public ExaminationTests(WebApplicationFactory<InterlayerController.Startup> factory)
        {
            _factory = factory;
        }

        string communicationLink = "http://localhost:51393";

        [Theory]
        [MemberData(nameof(ExaminationData))]
        public async void Cancel_examination(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.PutAsync(communicationLink + "/api/examination/canceled/" + id.ToString(), null);
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        [Theory]
        [MemberData(nameof(ExaminationData))]
        public async void Fill_survey(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.PutAsync(communicationLink + "/api/examination/" + id.ToString(), null);
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }

        /*[Theory]
        [MemberData(nameof(ExaminationData))]
        public async void Get_all_previous_by_user(long id, HttpStatusCode expectedStatusCode)
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/" + id.ToString());
            response.StatusCode.ShouldBeEquivalentTo(expectedStatusCode);
        }*/

        public static IEnumerable<object[]> ExaminationData =>
            new List<object[]>
            {
                new object[] {1,HttpStatusCode.OK},
                new object[] {2,HttpStatusCode.OK}
            };


    }
}
