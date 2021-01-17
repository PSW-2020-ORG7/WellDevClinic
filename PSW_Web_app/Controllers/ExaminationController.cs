using Microsoft.AspNetCore.Mvc;

using PSW_Web_app.Models.UserInteraction;
using PSW_Web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Controller;
using bolnica.Model;
using bolnica.Service;
using Model.Dto;
using WellDevCore.Model.Dto;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using WellDevCore.Model.dtos;
using System.Text;

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:61089";
        string communicationLink1 = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:62044";

        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("getAll")]
        public async Task<List<ExaminationDto>> GetFinishedExaminations()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/getAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return result;
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> FillSurvey(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink + "/api/examinationDetails/" + id, content);
            return Ok();
        }

        [HttpPut]
        [Route("canceled/{id?}")]
        public async Task<IActionResult> CancelExamination(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink + "/api/examination/canceled/" + id, content);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetFinishedExaminationsByUser(Patient patient)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/examinationDetails/getByPatient/", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDetails> result = JsonConvert.DeserializeObject<List<ExaminationDetails>>(responseBody);
            return Ok(result);

        }

        [HttpPost]
        [Route("upcoming")]
        public async Task<IActionResult> GetUpcomingExaminationsByUser(Patient patient)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink1 + "/api/upcomingExamination/GetUpcomingExaminationsByPatient/", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDetails> result = JsonConvert.DeserializeObject<List<ExaminationDetails>>(responseBody);
            return Ok(result);

        }
       /* [HttpGet]
        [Route("upcoming/{id?}")]
        public async Task<IActionResult> GetUpcomingExaminationsByUser(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/upcoming/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return Ok(result);
        }*/
        /// <summary>
        ///  calls GetFinishedExaminationsByUser(User user) method from class ExaminationService so  
        /// it can get examinations of specified user
        /// </summary>
        /// <param name="user">specified user</param>
        /// <returns>status 200 OK response with a list of examinations mapped to ExaminationDto</returns>
        [HttpGet]
        [Route("getByUser/{id?}")]
        public async Task<IActionResult> GetFinishedExaminationDocumentsByUser(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/getByUser/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return Ok(result);
        }

       /* [HttpPost]
        [Route("newExamination")]
        public async Task<IActionResult> NewExaminationAsync([FromBody] ExaminationIdsDTO examination)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(examination, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/examination/newExamination", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Examination result = JsonConvert.DeserializeObject<Examination>(responseBody);
            return Ok(result);
        }*/

        [HttpGet]
        [Route("prescription/{id?}")]
        public async Task<IActionResult> GetPrescriptionById(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/prescription/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Prescription result = JsonConvert.DeserializeObject<Prescription>(responseBody);
            return Ok(result);
        }

        [HttpGet]
        [Route("referral/{id?}")]
        public async Task<IActionResult> GetReferralById(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/referral/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Referral result = JsonConvert.DeserializeObject<Referral>(responseBody);
            return Ok(result);
        }

    }
}
