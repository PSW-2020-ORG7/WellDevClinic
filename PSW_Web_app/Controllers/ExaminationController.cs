using Microsoft.AspNetCore.Mvc;
using PSW_Web_app.Models.UserInteraction;
//using PSW_Web_app.Models.SearchAndSchedule;
using PSW_Web_app.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using PSW_Web_app.Models.Dtos;


namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("examinationServerAddress") ?? "http://localhost:61089";
        string communicationLink1 = Environment.GetEnvironmentVariable("searchAndScheduleServerAddress") ?? "http://localhost:62044";
        string communicationLink2 = Environment.GetEnvironmentVariable(" userInteractionServerAddress") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> FillSurvey(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink + "/api/examinationDetails/FillSurvey/" + id, content);
            return Ok();
        }

        [HttpPut]
        [Route("canceled/{id?}")]
        public async Task<IActionResult> CancelExamination(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink1 + "/api/upcomingExamination/Cancel/"+id, content);
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
            List<UpcomingExamination> result = JsonConvert.DeserializeObject<List<UpcomingExamination>>(responseBody);
            return Ok(result);

        }
        [HttpGet]
        [Route("upcoming/{id?}")]
        public async Task<IActionResult> GetUpcomingExaminationByUser(long id)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink1 + "/api/upcomingExamination/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            UpcomingExamination result = JsonConvert.DeserializeObject<UpcomingExamination>(responseBody);
            return Ok(result);
        }
        /// <summary>
        ///  calls GetFinishedExaminationsByUser(User user) method from class ExaminationService so  
        /// it can get examinations of specified user
        /// </summary>
        /// <param name="user">specified user</param>
        /// <returns>status 200 OK response with a list of examinations mapped to ExaminationDto</returns>
        [HttpPost]
        [Route("getByUser")]
        public async Task<IActionResult> GetFinishedExaminationDocumentsByUser(Patient patient)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            var content = new StringContent(JsonConvert.SerializeObject(patient, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/examinationDetails/getByPatient/", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDetails> result = JsonConvert.DeserializeObject<List<ExaminationDetails>>(responseBody);
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            foreach (ExaminationDetails e in result) {
                resultDto.Add(ExaminationMapper.ExaminationDetailsToExaminationDto(e));
            }
            return Ok(resultDto);

        }

        [HttpPost]
        [Route("newExamination")]
        public async Task<IActionResult> NewExaminationAsync(ExaminationDTO examination)
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();

            HttpResponseMessage responseDoctor = await client.GetAsync(communicationLink2 + "/api/doctor/eager/" + examination.DoctorId);
            responseDoctor.EnsureSuccessStatusCode();
            string responseBodyDoctor = await responseDoctor.Content.ReadAsStringAsync();
            Models.UserInteraction.Doctor resultDoctor = (Models.UserInteraction.Doctor)JsonConvert.DeserializeObject<Models.UserInteraction.Doctor>(responseBodyDoctor);

            HttpResponseMessage responsePatient = await client.GetAsync(communicationLink2 + "/api/patient/eager/" + examination.PatientId);
            responsePatient.EnsureSuccessStatusCode();
            string responseBodyPatient = await responsePatient.Content.ReadAsStringAsync();
            Models.UserInteraction.Patient resultPatient = (Models.UserInteraction.Patient)JsonConvert.DeserializeObject<Models.UserInteraction.Patient>(responseBodyPatient);

            ExaminationNew newExamination = new ExaminationNew(resultPatient, resultDoctor, new Period(examination.Start, examination.End));
            var content = new StringContent(JsonConvert.SerializeObject(newExamination, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink1 + "/api/upcomingexamination", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            UpcomingExamination result = JsonConvert.DeserializeObject<UpcomingExamination>(responseBody);
            return Ok(result);
        }

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
