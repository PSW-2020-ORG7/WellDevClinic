using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndBenefitsController : ControllerBase
    {
        private readonly IActionsAndBenefitsService _actionService;
        
        public ActionsAndBenefitsController(IActionsAndBenefitsService service)
        {
            _actionService = service;
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetBenefit(long id)
        {
            ActionAndBenefit act = _actionService.GetBenefit(id);
            if (act == null)
                return NotFound();
            return Ok(act);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
            => Ok(_actionService.GetAll());

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeleteBenefit(long id)
        {
            if (_actionService.DeleteBenefit(id))
                return Ok(true);
            return BadRequest();
        }

        [HttpPut]
        [Route("status/{id?}/{stat?}")]
        public IActionResult UpdateStatus(long id, int stat)
        {
            ActionAndBenefit action = _actionService.UpdateStatus(id, stat);
            if (action != null)
                return Ok(action);
            return BadRequest();
        }

        [HttpPut]
        [Route("deleteExpired")]
        public IActionResult DeleteExpired()
        {
            _actionService.DeleteExpiredAction();
            return Ok();
        }

    }
}
