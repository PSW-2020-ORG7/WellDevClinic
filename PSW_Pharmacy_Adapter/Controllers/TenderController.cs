using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        private readonly IPharmacyEmailsService _emailService;

        public TenderController(ITenderService tenderSevice, IPharmacyEmailsService emailService)
        {
            _tenderService = tenderSevice;
            _emailService = emailService;
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

        [HttpPut]
        [Route("winner/{id?}")]
        public IActionResult UpdateWinner(long id)
        {
            Tender tender = _tenderService.UpdateWinner(id);
            if (tender != null)
                return Ok(tender);
            return BadRequest();
        }

        [HttpGet]
        [Route("medications/{id?}")]
        public IActionResult GetTenderMedications(long id)
        {
            List<Medication> meds = _tenderService.GetTenderMedications(id);
            if (meds != null)
                return Ok(meds);
            return BadRequest();
        }

        [HttpPut]
        [Route("delete/{id?}")]
        public IActionResult DeleteTender(long id)
        {
            Tender ten = _tenderService.DeleteTender(id);
            if (ten != null)
                return Ok(ten);
            return BadRequest();
        }

        [HttpGet]
        [Route("email/{id?}")]
        public IActionResult SendEmailToWinner(long id)
        {
            bool isSend=_emailService.sendEmailToWinner(id);
            if (isSend == true)
                return Ok(isSend);
            return BadRequest();
        }
    }
}
