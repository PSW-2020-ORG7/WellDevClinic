using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;
using Model.Doctor;
using bolnica.Service;
using PSW_Web_app.DTO;
using PSW_Web_app.Adapters;
using bolnica.Model.Dto;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;


namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";

        static readonly HttpClient client = new HttpClient();
        [HttpPost]
        public async Task<IActionResult> SaveSurvey([FromBody] DoctorGrade survey)
        {
            string token = Request.Headers["Authorization"];
            if (!token.Equals("Patient"))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(survey, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/survey", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            DoctorGrade result = JsonConvert.DeserializeObject<DoctorGrade>(responseBody);
            return Ok(result);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string token = Request.Headers["Authorization"];
            if (!token.Equals("Secretary"))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/survey");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGradeDTO> result = JsonConvert.DeserializeObject<List<DoctorGradeDTO>>(responseBody);
            return Ok(result);
        }

      
        [HttpGet]
        [Route("{doctor?}")]
        public async Task<IActionResult> GetByDoctor(string doctor)
        {
            string token = Request.Headers["Authorization"];
            if (!token.Equals("Secretary"))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/survey/" + doctor);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGradeDTO> result = JsonConvert.DeserializeObject<List<DoctorGradeDTO>>(responseBody);
            return Ok(result);
        }

        [HttpPost]
        [Route("doctor_average")]
        public async Task<IActionResult> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            string token = Request.Headers["Authorization"];
            if (!token.Equals("Secretary"))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(surveys, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/survey/doctor_average", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<GradeDTO> result = JsonConvert.DeserializeObject<List<GradeDTO>>(responseBody);
            return Ok(result);
        }

    }


}
