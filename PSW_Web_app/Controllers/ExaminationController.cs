using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Controller;
using bolnica.Model;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Service;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService e) {
            _examinationService = e;
        }
        [HttpGet]
        public IActionResult GetFinishedxaminationsByUser()
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationService.GetAllPrevious();
            foreach (Examination examination in result) {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));//, referralDto, prescriptionDto)); 
            }
            return Ok(resultDto);
        }

    }
}
