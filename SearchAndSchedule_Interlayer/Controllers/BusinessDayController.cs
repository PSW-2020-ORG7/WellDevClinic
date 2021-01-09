using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;

namespace SearchAndSchedule_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDayController : ControllerBase
    {
        private readonly IBussinesDayAppService _businessDayAppService;

        public BusinessDayController(IBussinesDayAppService businessDayAppService)
        {
            _businessDayAppService = businessDayAppService;
        }

        [HttpPost]
        public BusinessDay Save(BusinessDay businessDay)
        {
            return _businessDayAppService.Save(businessDay);
        }

        [HttpGet]
        public List<BusinessDay> GetAll()
        {
            return _businessDayAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public BusinessDay Get(long id)
        {
            return _businessDayAppService.Get(id);
        }

        [HttpPut]
        [Route("Delete")]
        public void Delete(BusinessDay businessDay)
        {
            _businessDayAppService.Delete(businessDay);
        }


        [HttpPut]
        [Route("Edit")]
        public void Edit(BusinessDay businessDay)
        {
            _businessDayAppService.Edit(businessDay);
        }

        [HttpGet]
        [Route("ChangeDoctorShift")]
        public bool ChangeDoctorShift(BusinessDay newShift)
        {
            return _businessDayAppService.ChangeDoctorShift(newShift);
        }

        [HttpPost]
        [Route("GetBusinessDaysByDoctor")]
        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            return _businessDayAppService.GetBusinessDaysByDoctor(doctor);
        }

        [HttpPut]
        [Route("DeleteBusinessDayByRoom")]
        public void DeleteBusinessDayByRoom(Room room)
        {
            _businessDayAppService.DeleteBusinessDayByRoom(room);
        }

        //DTO za ova dva parametra ukoliko nekom treba metoda
        /*[HttpPost]
          [Route("GetExactDay")]
          public BusinessDay GetExactDay(Doctor doctor, DateTime date)
          {
               return _businessDayAppService.GetExactDay(doctor, date);
          }*/
        [HttpPost]
        [Route("IsExaminationPossible")]
        public bool IsExaminationPossible(UpcomingExamination examination)
        {
            return _businessDayAppService.IsExaminationPossible(examination);
        }

        [HttpPost]
        [Route("Search")]
        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            return _businessDayAppService.Search(businessDayDTO);
        }

        //DTO za ove parametre
       /* [HttpPost]
        [Route("OperationSearch")]
        public List<ExaminationDTO> OperationSearch(BusinessDayDTO businessDayDTO, double durationOfOperation)
        {
            return _businessDayAppService.OperationSearch(businessDayDTO, durationOfOperation);
        }*/
    }
}