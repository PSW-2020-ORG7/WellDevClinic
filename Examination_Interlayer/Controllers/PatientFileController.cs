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
    public class PatientFileController : ControllerBase
    {
        private readonly IPatientFileAppService _patientFileAppService;

        public PatientFileController(IPatientFileAppService patientFileAppService)
        {
            _patientFileAppService = patientFileAppService;
        }

        [HttpGet]
        public List<PatientFile> GetAll()
        {
            return _patientFileAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public PatientFile Get(long id)
        {
            return _patientFileAppService.Get(id);
        }

        [HttpGet]
        [Route("getByPatient/{id?}")]
        public PatientFile GetByPatient(long id)
        {
            return _patientFileAppService.GetPatientFileByPatient(id);
        }

        [HttpPost]
        public PatientFile Save(PatientFile patientFile)
        {
            return _patientFileAppService.Save(patientFile);
        }
    }
}