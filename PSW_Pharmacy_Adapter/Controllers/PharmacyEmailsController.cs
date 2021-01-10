using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyEmailsController : ControllerBase
    {
        private readonly IPharmacyEmailsService _emailsService;

        public PharmacyEmailsController(IPharmacyEmailsService pharmacyEmailsService)
        {
            _emailsService = pharmacyEmailsService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddEmail([FromBody] PharmacyEmails email)
        {
            PharmacyEmails newEmail = _emailsService.AddEmail(email);
            if (newEmail != null)
                return Ok(newEmail);
            return BadRequest();
        }
    }
}
