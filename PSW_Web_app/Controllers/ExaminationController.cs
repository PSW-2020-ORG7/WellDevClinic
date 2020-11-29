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
using Model.Dto;
using WellDevCore.Model.Dto;
using System.Globalization;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IReferralService _referralService;

        public ExaminationController(IExaminationService e, IReferralService referralService, IPrescriptionService prescriptionService) {
            _examinationService = e;
            _referralService = referralService;
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        [Route("getAll")]
        public IActionResult GetFinishedxaminations()
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationService.GetAllPrevious();
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

        [HttpPost]
        [Route("getByUser")]
        public IActionResult GetFinishedxaminationsByUser([FromBody] Patient user)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationService.GetFinishedxaminationsByUser(user);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

        [HttpPost]
        public IActionResult SearchPreviousExamination([FromBody] DocumentsDTO documentsDTO)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();

            List<Examination> result = _examinationService.SearchPreviousExamination(documentsDTO.Date, documentsDTO.Doctor, documentsDTO.Drug, documentsDTO.Specialist, documentsDTO.User);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

        [HttpPost]
        [Route("search")]
        public IActionResult SearchExamination([FromBody] DocumentsDTO2 documentsDTO2)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();

            List<Examination> result = _examinationService.SearchPreviousExaminations(documentsDTO2.Date, documentsDTO2.Doctor, documentsDTO2.Drug, documentsDTO2.Specialist, documentsDTO2.Radio1, documentsDTO2.Radio2);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

    }
}
