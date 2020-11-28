using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIKeyController : ControllerBase
    {
        private readonly APIKeyService KeyService;

        public APIKeyController()
        {
            MyContextFactory cf = new MyContextFactory();
            KeyService = new APIKeyService(cf.CreateDbContext(new string[0]));
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetPharmacy(string id)
        {
            Api api = KeyService.GetPharmacy(id);
            if (api == null)
                return NotFound();
            return Ok(api);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllPharmacies()
            => Ok(KeyService.GetAllPharmacies());

        [HttpPost]
        [Route("add")]
        public IActionResult AddPharmacy(Api api)
        {
            if (KeyService.AddPharmacy(api))
                return Ok(true);
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeletePharmacy(string id)
        {
            if (KeyService.DeletePharmacy(id))
                return Ok(true);
            return NotFound();
        }
    }
}
