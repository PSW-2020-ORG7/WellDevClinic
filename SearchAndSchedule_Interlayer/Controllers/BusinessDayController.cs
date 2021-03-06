﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        static readonly HttpClient client = new HttpClient();
        string communicationLink = Environment.GetEnvironmentVariable("userInteractionServerAddress") ?? "http://localhost:14483";


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

        [HttpPost]
        [Route("GetExactDay")]
        public BusinessDay GetExactDay(ExactDayDTO exactDay)
        {
             return _businessDayAppService.GetExactDay(exactDay.Doctor, exactDay.Date);
        }
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

        [HttpGet]
        [Route("{date?}/{id?}")]
        public async Task<List<ExaminationDTO>> GetAvailablePeriodsByDoctor(DateTime date, long id)
        {
            HttpResponseMessage response = await client.GetAsync(communicationLink + "/api/doctor/lazy/" + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Doctor result = (Doctor)JsonConvert.DeserializeObject<Doctor>(responseBody);
            return _businessDayAppService.Search(new BusinessDayDTO(result, new Period(date), PriorityType.NoPriority));
        }

        [HttpPost]
        [Route("markAsOccupied/{id?}")]
        public void MarkAsOccupied(List<Period> period, long id)
        {
            BusinessDay businessDay = _businessDayAppService.Get(id);
            _businessDayAppService.MarkAsOccupied(period, businessDay);


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