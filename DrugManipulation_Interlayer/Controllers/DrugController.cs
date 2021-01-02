using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DrugManipulation_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IDrugAppService _drugAppService;

        public DrugController(IDrugAppService drugAppService)
        {
            _drugAppService = drugAppService;
        }

        [HttpGet]
        public List<Drug> GetAll()
        {
            return _drugAppService.GetAll().DefaultIfEmpty().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Drug GetLazy(long id)
        {
            return _drugAppService.Get(id);
        }

        [HttpPut]
        public void Edit(Drug drug)
        {
            _drugAppService.Edit(drug);
        }

        [HttpPost]
        public Drug AddDrug([FromBody] Drug drug)
        {
            return _drugAppService.Save(drug);
        }

        [HttpGet]
        [Route("getNotApproved")]
        public List<Drug> GetNotApprovedDrugs()
        {
            return _drugAppService.GetNotApprovedDrugs().DefaultIfEmpty().ToList();
        }
    }
}