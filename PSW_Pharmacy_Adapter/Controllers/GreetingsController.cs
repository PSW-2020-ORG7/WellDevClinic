using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Service;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly GreetingsService _GreetService;

        public GreetingsController()
        {
            MyContextFactory cf = new MyContextFactory();
            _GreetService = new GreetingsService(cf.CreateDbContext(new string[0]), new HttpClient());
        }

        [HttpGet]
        [Route("greet/{id?}")]
        public async Task<IActionResult> GreetPharmacyAsync(string id)
        {
            HttpResponseMessage response = await _GreetService.GreetPharmacy(id);

            if (response.StatusCode.Equals(403))
                return Forbid();
            return Ok();
        }
    }
}
