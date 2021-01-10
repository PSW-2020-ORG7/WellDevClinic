using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Service;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();
        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/feedback");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Feedback> result = JsonConvert.DeserializeObject<List<Feedback>>(responseBody);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetFeedback(long id)
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink+ "/api/feedback/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Feedback result = JsonConvert.DeserializeObject<Feedback>(responseBody);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveFeedback(Feedback feedback)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(feedback, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink+ "/api/feedback", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Feedback result = JsonConvert.DeserializeObject<Feedback>(responseBody);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PublishFeedback(Feedback feedback)
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(feedback, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(communicationLink+ "/api/feedback", content);
            return Ok();
        }

    }
}
