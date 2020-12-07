using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Users;
using bolnica.Service;
using System.Net.Http;
using WellDevCore.Model.dtos;
using Newtonsoft.Json;
using System.Text;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    { 
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("patients_for_blocking")]
        public  async Task<List<PatientDTO>> GetPatientsForBlocking()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/patient/patients_for_blocking");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PatientDTO> patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);
            return patients;
        }

        [HttpGet]
        [Route("blocked_patients")]
        public  async Task<List<PatientDTO>> GetBlockedPatients()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/patient/blocked_patients");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PatientDTO> patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);
            return patients;
        }

        [HttpPut]
        [Route("{id?}")]
        public async void BlockPatient(long id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:51393/api/patient/"+ id ,content);

        }
    }
}