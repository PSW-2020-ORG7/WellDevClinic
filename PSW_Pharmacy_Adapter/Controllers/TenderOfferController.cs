﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Tender_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TenderOfferController : ControllerBase
    {
        private readonly ITenderOfferService _tenderOfferService;

        public TenderOfferController(ITenderOfferService tenderOfferSevice)
        {
            _tenderOfferService = tenderOfferSevice;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddOffer([FromBody] TenderOffer offer)
        {
            TenderOffer tenderOffer = _tenderOfferService.AddOffer(offer);
            if (tenderOffer != null)
                return Ok(tenderOffer);
            return BadRequest();
        }


        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetTenderOffers(long id)
        {
            List<TenderOffer> offers = _tenderOfferService.GetTenderOffers(id);
            if (offers != null)
                return Ok(offers);
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete/{id?}")]
        public IActionResult DeleteTenderOffer(long id)
        {
            if(_tenderOfferService.DeleteTenderOffer(id))
                return Ok(true);
            return BadRequest();
        }

    }
}
