using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKeyService _keyService;

        public ApiKeyController(IApiKeyService apiKeyService)
        {
            _keyService = apiKeyService;
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetPharmacy(string id)
        {
            Api api = _keyService.GetPharmacy(id);
            if (api == null)
                return NotFound();
            return Ok(api);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllPharmacies()
            => Ok(_keyService.GetAllPharmacies());

        [HttpPost]
        [Route("add")]
        public IActionResult AddPharmacy(Api api)
        {
            Api a = _keyService.AddPharmacy(api);
            if (a != null)
                return StatusCode(201, a);
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeletePharmacy(string id)
        {
            if (_keyService.DeletePharmacy(id))
                return Ok(true);
            return NotFound();
        }
    }
}
