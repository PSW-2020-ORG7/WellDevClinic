using bolnica.Controller;
using bolnica.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private IBusinessDayController _businessDayController;

        public TermController(IBusinessDayController dayController)
        {
            _businessDayController = dayController;
        }

        [HttpPost]
        //[Route("loginuser")]
        public List<ExaminationDTO> FindTerms(BusinessDayDTO businessDTO)
        {
            List<ExaminationDTO> exams = _businessDayController.Search(businessDTO);

           // List<ExaminationDTO2> ret = new List<ExaminationDTO2>();

          /*  foreach (var item in exams)
            {
                ret.Add(new ExaminationDTO2() { Doctor = (item.Doctor.FirstName + " " + item.Doctor.LastName), DoctorId = item.Doctor.Id, RoomId = item.Room.Id, StartDate = item.Period.StartDate, EndDate = item.Period.EndDate });

            }*/

            return exams;
        }
    }
}
