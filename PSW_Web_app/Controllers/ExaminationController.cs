using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using Model.Users;
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
using System.Text;

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";

        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetFinishedExaminations()
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/getAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            IActionResult result = JsonConvert.DeserializeObject<IActionResult>(responseBody);
            return result;
        }

        [HttpPut]
        [Route("{id?}")]
        public async void FillSurvey(long id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink + "/api/examination/" + id, content);
        }

        [HttpPut]
        [Route("canceled/{id?}")]
        public async void CancelExamination(long id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id));
            var response = await client.PutAsync(communicationLink + "/api/examination/canceled/" + id, content);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<List<ExaminationDto>> GetFinishedExaminationsByUser(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/"+id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return result;
        }
        [HttpGet]
        [Route("upcoming/{id?}")]
        public async Task<List<ExaminationDto>> GetUpcomingExaminationsByUser(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/upcoming/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return result;
        }
        /// <summary>
        ///  calls GetFinishedExaminationsByUser(User user) method from class ExaminationService so  
        /// it can get examinations of specified user
        /// </summary>
        /// <param name="user">specified user</param>
        /// <returns>status 200 OK response with a list of examinations mapped to ExaminationDto</returns>
        [HttpGet]
        [Route("getByUser/{id?}")]
        public async Task<List<ExaminationDto>> GetFinishedExaminationDocumentsByUser(long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/examination/getByUser/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return result;
        }
       
        [HttpPost]
        public async Task<List<ExaminationDto>> SearchPreviousExamination([FromBody] DocumentsDTO documentsDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(documentsDTO, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/examination", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            List<ExaminationDto> result = JsonConvert.DeserializeObject<List<ExaminationDto>>(responseBody);
            return result;
        }

        [HttpPost]
        [Route("search")]
        public IActionResult SearchExamination([FromBody] DocumentsDTO2 documentsDTO2)
        {
            throw new NotImplementedException();
        }
    }
}
