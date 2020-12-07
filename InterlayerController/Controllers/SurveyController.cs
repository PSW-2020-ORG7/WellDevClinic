using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using bolnica.Model.Dto;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Doctor;
using PSW_Web_app.Adapters;
using PSW_Web_app.DTO;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IDoctorGradeController _doctorGradeController;

        public SurveyController(IDoctorGradeController doctorGradeController)
        {
            _doctorGradeController = doctorGradeController;
        }

        [HttpPost]
        public DoctorGrade SaveSurvey([FromBody] DoctorGrade survey)
        {
            DoctorGrade result = _doctorGradeController.Save(survey);
            return result;
        }

        /// <summary>
        /// Gets all surveys and maps them on DoctorGradeDTO 
        /// </summary>
        /// <returns>List of mapped surveys</returns>
        [HttpGet]
        public List<DoctorGradeDTO> GetAll()
        {
            List<DoctorGrade> list = (List<DoctorGrade>)_doctorGradeController.GetAll();
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
            List<DoctorGrade> list = _doctorGradeController.GetByDoctor(doctor);
            List<DoctorGradeDTO> result = new List<DoctorGradeDTO>();
            foreach (DoctorGrade doctorGrade in list)
                result.Add(DoctorGradeAdapter.DoctorGradeToDoctorGradeDTO(doctorGrade));
            return result;
        }

        [HttpPost]
        [Route("doctor_average")]
        public List<GradeDTO> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            return _doctorGradeController.GetAverageGradeDoctor(surveys);
        }

    }

}
