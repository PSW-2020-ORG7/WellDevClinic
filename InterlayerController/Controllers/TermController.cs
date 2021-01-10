using bolnica.Controller;
using bolnica.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Users;
using System.Collections.Generic;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private IBusinessDayController _businessDayController;
        private IDoctorController _doctorController;


        public TermController(IBusinessDayController dayController, IDoctorController doctorController)
        {
            _businessDayController = dayController;
            _doctorController = doctorController;


        }

        [HttpPost]
        //[Route("loginuser")]
        public List<ExaminationDTO> FindTerms(BusinessDayDTO businessDTO)
        {
            List<ExaminationDTO> exams = _businessDayController.Search(businessDTO);

            return exams;
        }
        [HttpGet]
        [Route("{doctorId?}")]
        public BusinessDayDTO GetBusinessDay(long doctorId)
        {
            Doctor d = _doctorController.Get(doctorId);
            List<BusinessDay> businessDays = _businessDayController.GetBusinessDaysByDoctor(d);
            BusinessDayDTO business = new BusinessDayDTO()
            {
                Id = businessDays[0].Id,
                RoomId = businessDays[0].room.Id
            };
            return business;
        }
    }
}
