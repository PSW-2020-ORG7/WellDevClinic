using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Examination_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizationController : ControllerBase
    {
        private readonly IHospitalizationAppService _hospitalizationAppService;

        public HospitalizationController(IHospitalizationAppService hospitalizationAppService)
        {
            _hospitalizationAppService = hospitalizationAppService;
        }

        [HttpGet]
        public List<Hospitalization> GetAll()
        {
            return _hospitalizationAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Hospitalization Get(long id)
        {
            return _hospitalizationAppService.Get(id);
        }

        [HttpPost]
        public Hospitalization Save(Hospitalization hospitalization)
        {
            return _hospitalizationAppService.Save(hospitalization);
        }
    }
}