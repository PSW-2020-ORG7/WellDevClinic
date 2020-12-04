using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Users;
using bolnica.Service;
using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("{id?}")]
        public Patient GetPatientById(long id)
        {
            Patient patient = _patientService.Get(id);
            patient.Id = id;
            return patient;
        }

        [HttpGet]
        [Route("patientFile/{id?}")]
        public PatientDto GetPatientByIdDto(long id)
        {
            Patient patient = _patientService.Get(id);
            return PatientAdapter.PatientToPatientDto(patient);
        }

    }
}