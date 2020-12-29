using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TenderOfferController : ControllerBase
    {
        private readonly ITenderOfferService _keyService;

        public TenderOfferController(ITenderOfferService tenderOfferSevice)
        {
            _keyService = tenderOfferSevice;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddOffer([FromBody] TenderOffer offer)
        {
            TenderOffer tenderOffer = _keyService.AddOffer(offer);
            if (tenderOffer != null)
                return Ok(tenderOffer);
            return BadRequest();
        }
    }
}
