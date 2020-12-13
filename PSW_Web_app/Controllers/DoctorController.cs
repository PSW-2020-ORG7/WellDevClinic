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
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("{date?}/{id?}")]
        public async Task<List<Period>> GetAvailablePeriodsByDoctor(DateTime date, long id)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/doctor/" + date.ToString() + '/' + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Period> result = (List<Period>)JsonConvert.DeserializeObject<List<Period>>(responseBody);
            return result;
        }

        [HttpGet]
        [Route("{speciality?}")]
        public async Task<List<DoctorDTO>> GetDoctorsBySpeciality(String speciality)
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/doctor/" + speciality);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<DoctorDTO> result = (List<DoctorDTO>)JsonConvert.DeserializeObject<List<DoctorDTO>>(responseBody);
            return result;
        }
    }
}
