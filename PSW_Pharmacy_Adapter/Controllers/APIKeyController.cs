using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIKeyController : ControllerBase
    {
        IAPIKeyRepository KeyRepo;

        public APIKeyController()
        {
            MyContextFactory cf = new MyContextFactory();
            KeyRepo = new APIKeyRepository(cf.CreateDbContext(new string[0]));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddPharmacy(Api api)
        {
            if (KeyRepo.Save(api))
                return Ok();    
            return BadRequest();
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetPharmacy(string id)
        {
            Api api = KeyRepo.Get(id);
            if (api == null)
                return NotFound();
            return Ok(api);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllPharmacies() =>
            Ok(KeyRepo.GetAll());

        [HttpPut]
        [Route("/delete/{id?}")]
        public IActionResult DeletePharmacy(string id)
        {
            if (KeyRepo.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
