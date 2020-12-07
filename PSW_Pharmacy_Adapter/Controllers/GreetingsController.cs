using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Service;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IGreetingsService _GreetService;

        public GreetingsController(IGreetingsService greetingsService)
        {
            MyContextFactory cf = new MyContextFactory();
            _GreetService = new GreetingsService(cf.CreateDbContext(new string[0]), new HttpClient());
            //_GreetService = greetingsService;
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
