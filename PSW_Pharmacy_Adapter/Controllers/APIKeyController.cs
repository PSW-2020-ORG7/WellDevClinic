using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIKeyController : ControllerBase
    {
        IAPIKeyRepository pr = new APIKeyRepository();

        [HttpPost]
        [Route("add")]
        public IActionResult AddPharmacy(Api api)
        {
            bool success = pr.Save(api);
            if (success)
                return Ok();    
            return BadRequest();
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetPharmacy(string id)
        {
            Api api = pr.Get(id);
            if (api == null)
                return NotFound();
            return Ok(api);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllPharmacies() =>
            Ok(pr.GetAll());

        [HttpPut]
        [Route("/delete/{id?}")]
        public IActionResult DeletePharmacy(string id)
        {
            bool success = pr.Delete(id);
            if (success)
                return Ok();
            return NotFound();
        }


    }
}
