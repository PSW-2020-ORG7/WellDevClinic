using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica;
using Model.Doctor;
using Model.Users;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;
        private readonly IDoctorService _doctorService;
        public AppointmentController(ISpecialityService specialityService, IDoctorService doctorService)
        {
            _specialityService = specialityService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public List<Speciality> GetAllSpeciality()
        {
            List<Speciality> list = (List<Speciality>) _specialityService.GetAll();
            return list;
        }

        [HttpGet]
        [Route("{speciality?}")]
        public List<Doctor> GetDoctorsBySpeciality(String speciality)
        {
            Speciality instance = new Speciality(speciality);
            List<Doctor> doctors = _doctorService.GetDoctorsBySpeciality(instance);
            return doctors;
        }
    }
}
