using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : ControllerBase
    {
        //private readonly ActionsAndBenefitsService _ActionService;
        private readonly IActionsAndBenefitsService _ActionService;
        
        public ActionsAndBenefitsController(IActionsAndBenefitsService serice)
        {
            //MyContextFactory cf = new MyContextFactory();
            //_ActionService = new ActionsAndBenefitsService(cf.CreateDbContext(new string[0]));
            _ActionService = serice;
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetBenefit(long id)
        {
            ActionAndBenefit act = _ActionService.GetBenefit(id);
            if (act == null)
                return NotFound();
            return Ok(act);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
            => Ok(_ActionService.GetAll());

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeleteBenefit(long id)
        {
            if (_ActionService.DeleteBenefit(id))
                return Ok(true);
            return BadRequest();
        }
    }
}
