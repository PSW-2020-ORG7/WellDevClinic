using Microsoft.AspNetCore.Mvc;
using Model.Doctor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> GetAllSpeciality()
        {
            if (!Authorization.Authorize("Patient", Request.Headers["Authorization"]))
                return BadRequest();
            HttpResponseMessage response = await client.GetAsync(communicationLink  + "/api/speciality");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Speciality> result = (List<Speciality>)JsonConvert.DeserializeObject<List<Speciality>>(responseBody);
            return Ok(result);
        }
    }
}
