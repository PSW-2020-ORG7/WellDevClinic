using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using bolnica;
using Model.Users;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
       
        [HttpPost]
        public async Task<Patient> UserRegistration([FromBody] Patient entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:51393/api/registration", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Patient result = JsonConvert.DeserializeObject<Patient>(responseBody);
            return result;
        }


    }
}
