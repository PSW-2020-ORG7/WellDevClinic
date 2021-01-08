using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderSevice)
        {
            _tenderService = tenderSevice;
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            List<Tender> tenders = _tenderService.GetAllTenders();
            if (tenders != null)
                return Ok(tenders);
            return BadRequest();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddTender([FromBody] Tender tender)
        {
            Tender newTender = _tenderService.AddTender(tender);
            if (newTender != null)
                return Ok(newTender);
            return BadRequest();
        }

        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetTender(long id)
        {
            Tender tender = _tenderService.GetTender(id);
            if (tender != null)
                return Ok(tender);
            return BadRequest();
        }
        

    }
}
