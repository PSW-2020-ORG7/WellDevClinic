using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using Model.Users;
using WellDevCore.Model.Dto;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationController _examinationController;

        public ExaminationController(IExaminationController examinationController)
        {
            _examinationController = examinationController;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetFinishedxaminations()
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetAllPrevious();
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }

        /// <summary>
        ///  calls GetFinishedxaminationsByUser(User user) method from class ExaminationService so  
        /// it can get examinations of specified user
        /// </summary>
        /// <param name="user">specified user</param>
        /// <returns>status 200 OK response with a list of examinations mapped to ExaminationDto</returns>
        [HttpPost]
        [Route("getByUser")]
        public IActionResult GetFinishedxaminationsByUser([FromBody] Patient user)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = (List<Examination>)_examinationController.GetFinishedxaminationsByUser(user);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));
            }
            return Ok(resultDto);
        }
        /// <summary>
        /// calls SearchPreviousExamination(String date, String doctorName, String drugName, String speacialistName, User user)
        /// method from class ExaminationService so  it get filtered examinations
        /// <param name="documentsDTO"></param>
        /// <returns>status 200 OK response with a list of feedback filtered examinations mapped to ExaminationDto</returns>
        [HttpPost]
        public IActionResult SearchPreviousExamination([FromBody] DocumentsDTO documentsDTO)
        {
            List<ExaminationDto> resultDto = new List<ExaminationDto>();
            List<Examination> result = _examinationController.SearchPreviousExamination(documentsDTO.Date, documentsDTO.Doctor, documentsDTO.Drug, documentsDTO.Specialist, documentsDTO.User);
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

            List<Examination> result = _examinationController.SearchPreviousExaminations(documentsDTO2.Date, documentsDTO2.Doctor, documentsDTO2.Drug, documentsDTO2.Specialist, documentsDTO2.Radio1, documentsDTO2.Radio2);
            foreach (Examination examination in result)
            {
                resultDto.Add(ExaminationAdapter.ExaminationToExaminationDto(examination));

            }
            return Ok(resultDto);
        }

        [HttpPost]
        [Route("newExamination")]
        public Examination NewExamination([FromBody] ExaminationIdsDTO examination) 
        {
            Examination retVal = _examinationController.NewExamination(examination.DoctorId, examination.PeriodId);
            return retVal;
        }
    }
}
