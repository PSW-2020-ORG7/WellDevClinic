using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using PSW_Web_app.Models;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();
        [HttpPost]
        public async Task<IActionResult> SaveSurvey([FromBody] DoctorGrade survey)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(survey, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/doctorGrade", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            DoctorGrade result = JsonConvert.DeserializeObject<DoctorGrade>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctorGrade");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGrade> result = JsonConvert.DeserializeObject<List<DoctorGrade>>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        [Route("{doctor?}")]
        public async Task<IActionResult> GetByDoctor(string doctor)
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctorGrade/doctor/" + doctor);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGrade> result = JsonConvert.DeserializeObject<List<DoctorGrade>>(responseBody);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("doctor_average")]
        public async Task<IActionResult> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(surveys, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/doctorGrade/doctor_average", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGradeQuestion> result = JsonConvert.DeserializeObject<List<DoctorGradeQuestion>>(responseBody);
            return Ok(result);
        }
        
    }


}
