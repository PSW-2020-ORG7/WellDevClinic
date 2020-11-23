using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bolnica.Model.Users;
using Model.Doctor;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private bolnica.Controller.IDoctorGradeController _doctorGradeController = new Controller.DoctorGradeController();


        [HttpPost]
        public DoctorGrade SaveSurvey([FromBody] DoctorGrade survey)
        {
            DoctorGrade result = _doctorGradeController.Save(survey);
            return result;
        }

        [HttpGet]
        public List<DoctorGrade> GetAll()
        {
            List<DoctorGrade> result = (List<DoctorGrade>)_doctorGradeController.GetAll();
            return result;
        }

    }


}
