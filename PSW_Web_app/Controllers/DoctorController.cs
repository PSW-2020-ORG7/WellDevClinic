using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PSW_Web_app.Models.UserInteraction;
using Doctor = PSW_Web_app.Models.UserInteraction.Doctor;
using PSW_Web_app.Models;
using PSW_Web_app.Models.Dtos;

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("userInteractionServerAddress") ?? "http://localhost:14483";
        string communicationLink2 = Environment.GetEnvironmentVariable("searchAndScheduleServerAddress") ?? "http://localhost:62044";

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
        public async Task<List<BusinessDayDTO>> GetAvailablePeriodsByDoctor(DateTime date, long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink2 + "/api/businessday/" + date.ToString() + '/' + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<BusinessDayDTO> result = (List<BusinessDayDTO>)JsonConvert.DeserializeObject<List<BusinessDayDTO>>(responseBody);
            return result;
        }

        [HttpGet]
        [Route("{speciality?}")]
        public async Task<List<Doctor>> GetDoctorsBySpeciality(String speciality)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/getBySpeciality/" + speciality); //+ "Id=" + spec.Id.ToString() + "&" + "Name=" + spec.Name
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Doctor> result = (List<Doctor>)JsonConvert.DeserializeObject<List<Doctor>>(responseBody);
            return result;
        }
    }
}
