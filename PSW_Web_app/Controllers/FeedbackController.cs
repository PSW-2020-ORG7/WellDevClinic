using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;
using bolnica.Service;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";

        static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<List<Feedback>> GetAllFeedback()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/feedback");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Feedback> result = JsonConvert.DeserializeObject<List<Feedback>>(responseBody);
            return result;
        }

        
        [HttpGet]
        [Route("{id?}")]
        public async Task<Feedback> GetFeedback(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink+ "/api/feedback/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Feedback result = JsonConvert.DeserializeObject<Feedback>(responseBody);
            return result;
        }

        [HttpPost]
        public async Task<Feedback> LeaveFeedback([FromBody] Feedback feedback)
        {
            var content = new StringContent(JsonConvert.SerializeObject(feedback, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink+ "/api/feedback", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Feedback result = JsonConvert.DeserializeObject<Feedback>(responseBody);
            return result;
        }


      
        [HttpPut]
        public async void PublishFeedback(Feedback feedback)
        {
            var content = new StringContent(JsonConvert.SerializeObject(feedback, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(communicationLink+ "/api/feedback", content);
 
        }

    }
}
