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
    public class ExaminationDetailsController : ControllerBase
    {
        private readonly IExaminationDetailsAppService _examinationDetailsAppService;

        public ExaminationDetailsController(IExaminationDetailsAppService examinationDetailsAppService)
        {
            _examinationDetailsAppService = examinationDetailsAppService;
        }

        [HttpGet]
        public List<ExaminationDetails> GetAll()
        {
            return _examinationDetailsAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public ExaminationDetails Get(long id)
        {
            return _examinationDetailsAppService.Get(id);
        }

        [HttpPost]
        public ExaminationDetails Save(ExaminationDetails examinationDetails)
        {
            return _examinationDetailsAppService.Save(examinationDetails);
        }

        [HttpGet]
        [Route("getByDoctor/{doctor?}")]
        public List<ExaminationDetails> GetExaminationDetailsByDoctor(Doctor doctor)
        {
            return _examinationDetailsAppService.GetExaminationDetailsByDoctor(doctor).ToList();
        }

        [HttpGet]
        [Route("getByPaitent/{patient?}")]
        public List<ExaminationDetails> GetExaminationDetailsByPatient(Patient patient)
        {
            return _examinationDetailsAppService.GetExaminationDetailsByPatient(patient).ToList();
        }

        [HttpPost]
        [Route("getByPatient")]
        public List<ExaminationDetails> GetExaminationsByPatient(Patient patient)
        {
            return _examinationDetailsAppService.GetExaminationDetailsByPatient(patient).ToList();
        }

        [HttpPut]
        [Route("FillSurvey/{id?}")]
        public void FillSurvey(long id)
        {
            _examinationDetailsAppService.FillSurvey(id);
        }

    }
}