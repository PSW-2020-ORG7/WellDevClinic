using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PSW_Web_app.Models;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        string communicationLink = Environment.GetEnvironmentVariable("server_address") ?? "http://localhost:14483";

        static readonly HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user, Formatting.Indented), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(communicationLink + "/api/user/patient", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody.Length > 0)
                return Ok(responseBody);
            else
                return Unauthorized();
        }
    }
}
