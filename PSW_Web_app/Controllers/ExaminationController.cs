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

namespace PSW_Web_app.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetFinishedxaminations()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:51393/api/examination/getAll");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            IActionResult result = JsonConvert.DeserializeObject<IActionResult>(responseBody);
            return result;
        }

       
        [HttpGet]
        [Route("getByUser")]
        public IActionResult GetFinishedxaminationsByUser([FromBody]Patient user)
        {
            return Ok(null);
        }
       
        [HttpPost]
        public IActionResult SearchPreviousExamination([FromBody] DocumentsDTO documentsDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("search")]
        public IActionResult SearchExamination([FromBody] DocumentsDTO2 documentsDTO2)
        {
            throw new NotImplementedException();
        }
    }
}
