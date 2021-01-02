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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorAppService _doctorAppService;

        public DoctorController(IDoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }

        [HttpGet]
        public List<Doctor> GetAll()
        {
            return _doctorAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Doctor GetLazy(long id)
        {
            return _doctorAppService.Get(id);
        }

        [HttpGet]
        [Route("eager/{id?}")]
        public Doctor GetEager(long id)
        {
            return _doctorAppService.GetEager(id);
        }

        [HttpPut]
        public void Edit(Doctor doctor)
        {
            _doctorAppService.Edit(doctor);
        }

        [HttpGet]
        [Route("getBySpeciality/{speciality?}")]
        public List<Doctor> GetDoctorsBySpeciality(Speciality speciality)
        {
            return _doctorAppService.GetDoctorsBySpeciality(speciality).ToList();
        }
    }
}