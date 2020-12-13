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
    public class DoctorController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:51393";

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
    }
}