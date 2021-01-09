using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Users;
using bolnica.Service;

using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

using System.Net.Http;

using Newtonsoft.Json;
using System.Text;


namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    { 
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:62948";

        static readonly HttpClient client = new HttpClient();
        //povezati sutra obavezno!!
        [HttpGet]
        [Route("patients_for_blocking")]
        public  async Task<List<PatientDTO>> GetPatientsForBlocking()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink +"/api/patient/patients_for_blocking");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PatientDTO> patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);
            return patients;
        }

        //Examination microservice
        [HttpGet]
        [Route("patientFile/{id?}")]
        public async Task<PatientDTO> GetPatientByIdDto(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/patientFile/"+id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            PatientDTO patient = JsonConvert.DeserializeObject<PatientDTO>(responseBody);
            return patient;
        }


        [HttpGet]
        [Route("blocked_patients")]
        public  async Task<List<PatientDTO>> GetBlockedPatients()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/blocked_patients");
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
            var response = await client.PutAsync(communicationLink + "/api/patient/"+ id ,content);

        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public async Task<Patient> GetPatientById(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/lazy/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Patient patient = JsonConvert.DeserializeObject<Patient>(responseBody);
            return patient;
        }

    }
}