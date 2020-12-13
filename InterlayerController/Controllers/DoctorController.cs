using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using Model.Users;
using WellDevCore.Model.Adapters;
using WellDevCore.Model.Dto;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorController _doctorController;

        public DoctorController(IDoctorController doctorController)
        {
            _doctorController = doctorController;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<DoctorDTO> resultDTO = new List<DoctorDTO>();
            List<Doctor> result = (List<Doctor>)_doctorController.GetAll();
            foreach (Doctor doctor in result)
            {
                resultDTO.Add(DoctorAdapter.DoctorToDoctorDTO(doctor));
            }
            return Ok(resultDTO);
        }
    }
}
