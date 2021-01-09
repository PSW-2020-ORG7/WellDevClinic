using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WellDevCore.Model.dtos;

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:62948";

        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            IActionResult result = JsonConvert.DeserializeObject<IActionResult>(responseBody);
            return result;
        }

        [Route("{date?}/{id?}")]
        public async Task<List<Period>> GetAvailablePeriodsByDoctor(DateTime date, long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/" + date.ToString() + '/' + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Period> result = (List<Period>)JsonConvert.DeserializeObject<List<Period>>(responseBody);
            return result;
        }

        [HttpGet]
        [Route("{speciality?}")]
        public async Task<List<Doctor>> GetDoctorsBySpeciality(String speciality)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/getBySpeciality/" + speciality);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Doctor> result = (List<Doctor>)JsonConvert.DeserializeObject<List<Doctor>>(responseBody);
            return result;
        }
    }
}
