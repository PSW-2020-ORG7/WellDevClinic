using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionAppService _prescriptionAppService;

        public PrescriptionController(IPrescriptionAppService prescriptionAppService)
        {
            _prescriptionAppService = prescriptionAppService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Prescription Get(long id)
        {
            Prescription p= _prescriptionAppService.Get(id);
            return p;
        }
    }
}
