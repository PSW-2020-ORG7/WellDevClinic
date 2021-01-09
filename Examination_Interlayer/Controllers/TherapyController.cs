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
    public class TherapyController : ControllerBase
    {
        private readonly ITherapyAppService _therapyAppService;

        public TherapyController(ITherapyAppService therapyAppService)
        {
            _therapyAppService = therapyAppService;
        }

        [HttpGet]
        public List<Therapy> GetAll()
        {
            return _therapyAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Therapy Get(long id)
        {
            return _therapyAppService.Get(id);
        }

        [HttpPost]
        public Therapy Save(Therapy therapy)
        {
            return _therapyAppService.Save(therapy);
        }
    }
}