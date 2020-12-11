using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly IGreetingsService _greetService;

        public GreetingsController(IGreetingsService greetingsService)
        {
            _greetService = greetingsService;
        }

        [HttpGet]
        [Route("greet/{id?}")]
        public async Task<IActionResult> GreetPharmacyAsync(string id)
        {
            HttpResponseMessage response = await _greetService.GreetPharmacy(id);

            if (response.StatusCode.Equals(403))
                return Forbid();
            return Ok();
        }
    }
}
