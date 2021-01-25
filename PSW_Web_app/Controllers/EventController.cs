using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSW_Web_app.Models;
using PSW_Web_app.Models.Dtos;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:62044";
        
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/event/getAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            NewExaminationTimeSpent result = JsonConvert.DeserializeObject<NewExaminationTimeSpent>(responseBody);
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(NewExaminationTimeSpent nets)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(nets, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/event/save/", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            NewExaminationTimeSpent result = JsonConvert.DeserializeObject<NewExaminationTimeSpent>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        [Route("max")]
        public async Task<IActionResult> GetMax()
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/event/max");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            long result = JsonConvert.DeserializeObject<long>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        [Route("stepTime")]
        public async Task<IActionResult> GetStepTime()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/event/stepTime");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            AverageTimeDTO result = JsonConvert.DeserializeObject<AverageTimeDTO>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        [Route("success")]
        public async Task<IActionResult> GetsuccessPercentage()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/event/success");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<long> result = JsonConvert.DeserializeObject<List<long>>(responseBody);
            return Ok(result);
        }
    }
}
