using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using PSW_Web_app.Models.UserInteraction;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();
       
        [HttpPost]
        public async Task<Patient> UserRegistration([FromBody] Patient entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/user", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Patient result = JsonConvert.DeserializeObject<Patient>(responseBody);
            return result;
        }


    }
}
