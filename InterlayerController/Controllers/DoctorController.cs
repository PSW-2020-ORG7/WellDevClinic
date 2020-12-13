using bolnica.Controller;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorController _doctorController;
        private readonly IBusinessDayController _businessDayController;
        public DoctorController(IDoctorController doctorController, IBusinessDayController businessDayController)
        {
            _doctorController = doctorController;
            _businessDayController = businessDayController;
        }

        [HttpGet]
        [Route("{date?}/{id?}")]
        public List<Period> GetAvailablePeriodsByDoctor(DateTime date,long id)
        {
            return _businessDayController.GetAvailablePeriodsByDoctor(date, id);
        }

        [HttpGet]
        [Route("{speciality?}")]
        public List<DoctorDTO> GetDoctorsBySpeciality(String speciality)
        {
            Speciality instance = new Speciality(speciality);
            List<Doctor> doctors = _doctorController.GetDoctorsBySpeciality(instance);
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>(); 
            foreach(Doctor d in doctors)
            {
                DoctorDTO doctor2 = DoctorAdapter.DoctorToDoctorDTO(d);
                if (d.BusinessDay.Count > 0)
                {
                    foreach (BusinessDay bd in d.BusinessDay.ToList())
                    {
                        doctor2.BusinessDayDTOs.Add(new BusinessDayDTO()
                        {
                            StartDate = bd.Shift.StartDate,
                            EndDate = bd.Shift.EndDate,
                            ShiftId = bd.Shift.Id,
                            BusinessDayId = bd.Id,
                            Room = bd.room,
                            ScheduledPeriods = bd.ScheduledPeriods
                        });
                    }
                }
                
                doctorDTOs.Add(doctor2);
            }
            return doctorDTOs;
        }
    }
}
