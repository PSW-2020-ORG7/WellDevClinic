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

// nemamo sta da gadjamo
namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:62948";

        static readonly HttpClient client = new HttpClient();
        [HttpPost]
        public async Task<DoctorGrade> SaveSurvey([FromBody] DoctorGrade survey)
        {
            var content = new StringContent(JsonConvert.SerializeObject(survey, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/doctorGrade", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            DoctorGrade result = JsonConvert.DeserializeObject<DoctorGrade>(responseBody);
            return result;
        }

       
        [HttpGet]
        public async Task<List<DoctorGrade>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctorGrade");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGrade> result = JsonConvert.DeserializeObject<List<DoctorGrade>>(responseBody);
            return result;
        }

      
        [HttpGet]
        [Route("{doctor?}")]
        public async Task<List<DoctorGradeDTO>> GetByDoctor(string doctor)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctorGrade/" + doctor);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorGradeDTO> result = JsonConvert.DeserializeObject<List<DoctorGradeDTO>>(responseBody);
            return result;
        }

        [HttpPost]
        [Route("doctor_average")]
        public async Task<List<GradeDTO>> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            var content = new StringContent(JsonConvert.SerializeObject(surveys, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/doctorGrade/doctor_average", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<GradeDTO> result = JsonConvert.DeserializeObject<List<GradeDTO>>(responseBody);
            return result;
        }

    }


}
