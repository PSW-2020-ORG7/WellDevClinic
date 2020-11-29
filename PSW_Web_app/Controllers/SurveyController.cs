using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;
using Model.Doctor;
using bolnica.Service;
using PSW_Web_app.DTO;
using PSW_Web_app.Adapters;
using bolnica.Model.Dto;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IDoctorGradeService _doctorGradeService;

        public SurveyController(IDoctorGradeService doctorGradeService)
        {
            _doctorGradeService = doctorGradeService;
        }

        [HttpPost]
        public DoctorGrade SaveSurvey([FromBody] DoctorGrade survey)
        {
            DoctorGrade result = _doctorGradeService.Save(survey);
            return result;
        }

        /// <summary>
        /// Gets all surveys and maps them on DoctorGradeDTO 
        /// </summary>
        /// <returns>List of mapped surveys</returns>
        [HttpGet]
        public List<DoctorGradeDTO> GetAll()
        {
            List<DoctorGrade> list = (List<DoctorGrade>)_doctorGradeService.GetAll();
            List<DoctorGradeDTO> result = new List<DoctorGradeDTO>();
            foreach (DoctorGrade doctorGrade in list)
                result.Add(DoctorGradeAdapter.DoctorGradeToDoctorGradeDTO(doctorGrade));
            return result;
        }

        /// <summary>
        /// Gets all surveys of specified doctor and maps them on DoctorGradeDTO 
        /// </summary>
        /// <param name="doctor">Specified doctor</param>
        /// <returns>List of mapped surveys</returns>
        [HttpGet]
        [Route("{doctor?}")]
        public List<DoctorGradeDTO> GetByDoctor(string doctor)
        {
            List<DoctorGrade> list =_doctorGradeService.GetByDoctor(doctor);
            List<DoctorGradeDTO> result = new List<DoctorGradeDTO>();
            foreach (DoctorGrade doctorGrade in list)
                result.Add(DoctorGradeAdapter.DoctorGradeToDoctorGradeDTO(doctorGrade));
            return result;
        }

        [HttpPost]
        [Route("doctor_average")]
        public List<GradeDTO> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            return _doctorGradeService.GetAverageGradeDoctor(surveys);
        }

    }


}
