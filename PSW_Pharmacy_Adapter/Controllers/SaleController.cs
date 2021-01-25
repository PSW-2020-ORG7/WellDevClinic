using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Sale_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        
        public SaleController(ISaleService service)
        {
            _saleService = service;
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetBenefit(long id)
        {
            Sale sale = _saleService.GetBenefit(id);
            if (sale == null)
                return NotFound();
            return Ok(sale);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
            => Ok(_saleService.GetAll());

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeleteBenefit(long id)
        {
            if (_saleService.DeleteBenefit(id))
                return Ok(true);
            return BadRequest();
        }

        [HttpPut]
        [Route("status/{id?}/{stat?}")]
        public IActionResult UpdateStatus(long id, int stat)
        {
            Sale action = _saleService.UpdateStatus(id, stat);
            if (action != null)
                return Ok(action);
            return BadRequest();
        }

        [HttpPut]
        [Route("deleteExpired")]
        public IActionResult DeleteExpired()
        {
            _saleService.DeleteExpiredAction();
            return Ok();
        }

    }
}
