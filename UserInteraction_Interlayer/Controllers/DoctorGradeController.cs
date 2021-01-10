using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorGradeController : ControllerBase
    {
        private readonly IDoctorGradeAppService _doctorGradeAppService;

        public DoctorGradeController(IDoctorGradeAppService doctorGradeAppService)
        {
            _doctorGradeAppService = doctorGradeAppService;
        }


        [HttpGet]
        public List<DoctorGrade> GetAll()
        {
            return _doctorGradeAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public DoctorGrade Get(long id)
        {
            return _doctorGradeAppService.Get(id);
        }

        [HttpPost]
        public DoctorGrade Save([FromBody] DoctorGrade doctorGrade)
        {
            return _doctorGradeAppService.Save(doctorGrade);
        }

        [HttpGet]
        [Route("{doctor?}")]
        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            return _doctorGradeAppService.GetByDoctor(doctor);
        }

        [HttpPost]
        [Route("doctor_average")]
        public List<DoctorGradeQuestion> GetAverageGradeDoctor([FromBody] List<DoctorGrade> surveys)
        {
            return _doctorGradeAppService.GetAverageGradeDoctor(surveys);
        }
    }
}