using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Model.Users;
using bolnica.Service;

using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

using System.Net.Http;

using Newtonsoft.Json;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    { 
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();
        //povezati sutra obavezno!!
        [HttpGet]
        [Route("patients_for_blocking")]
        public  async Task<IActionResult> GetPatientsForBlocking()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink +"/api/patient/patients_for_blocking");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PatientDTO> patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);
            return Ok(patients);
        }

        //Examination microservice
        [HttpGet]
        [Route("patientFile/{id?}")]
        public async Task<IActionResult> GetPatientByIdDto(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/patientFile/"+id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            PatientDTO patient = JsonConvert.DeserializeObject<PatientDTO>(responseBody);
            return Ok(patient);
        }


        [HttpGet]
        [Route("blocked_patients")]
        public  async Task<IActionResult> GetBlockedPatients()
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/patient/blocked_patients");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PatientDTO> patients = JsonConvert.DeserializeObject<List<PatientDTO>>(responseBody);
            return Ok(patients);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> BlockPatient(long id)
        {
            if (!Authorization.Authorize("Secretary", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(id, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(communicationLink + "/api/patient/"+ id ,content);
            return Ok();
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