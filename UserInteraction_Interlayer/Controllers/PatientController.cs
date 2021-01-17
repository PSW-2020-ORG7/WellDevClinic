using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientAppService _patientAppService;

        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        [HttpGet]
        public List<Patient> GetAll()
        {
            return _patientAppService.GetAll().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Patient GetLazy(long id)
        {
            return _patientAppService.Get(id);
        }

        [HttpGet]
        [Route("patientDetails/{id?}")]
        public Patient GetPatientDetails(long id)
        {
            return _patientAppService.GetPatientDetails(id);
        }

        [HttpGet]
        [Route("eager/{id?}")]
        public Patient GetEager(long id)
        {
            return _patientAppService.GetEager(id);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Patient patient)
        {
            _patientAppService.Edit(patient);
        }

        [HttpPut]
        [Route("block/{id?}")]
        public void Block(long id)
        {
            _patientAppService.Block(id);
        }

        [HttpPut]
        [Route("claimAcc")]
        public Patient ClaimAccount(Patient patient)
        {
            return _patientAppService.ClaimAccount(patient);
        }

        [HttpGet]
        [Route("getByJMBG/{jmbg}")]
        public Patient GetPatientByJMBG(String jmbg)
        {
            return _patientAppService.GetPatientByJMBG(jmbg);
        }

        [HttpGet]
        [Route("blocked_patients")]
        public List<Patient> GetBlockedPatients()
        {
            return _patientAppService.GetBlockedPatients();
        }
    }
}