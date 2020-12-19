using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using bolnica.Service;
using Microsoft.AspNetCore.Mvc;
using Model.Users;
using WellDevCore.Model.Adapters;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientController _patientController;

        public PatientController(IPatientController patientController)
        {
            _patientController = patientController;
        }

        [HttpGet]
        [Route("{id?}")]
        public Patient GetPatientById(long id)
        {
            Patient patient = _patientController.Get(id);
            patient.Id = id;
            return patient;
        }

        [HttpGet]
        [Route("patients_for_blocking")]
        public List<PatientDTO> GetPatientsForBlocking()
        {
            List<Patient> patients = _patientController.GetPatientsForBlocking();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(PatientAdapter.PatientToPatientDTO(patient));
            }
            return result;
        }

        [HttpGet]
        [Route("blocked_patients")]
        public List<PatientDTO> GetBlockedPatients()
        {
            List<Patient> patients = _patientController.GetBlockedPatients();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(PatientAdapter.PatientToPatientDTO(patient));
            }
            return result;
        }

        [HttpPut]
        [Route("{id?}")]
        public void BlockPatient(long id)
        {
            Patient patient = _patientController.Get(id);
            patient.Blocked = true;
            _patientController.Edit(patient);
        }

        [HttpGet]
        [Route("patientFile/{id?}")]
        public PatientDTO GetPatientByIdDto(long id)
        {
            Patient patient = _patientController.Get(id);
           
            return PatientAdapter.PatientToPatientDto(patient);
        }

        [HttpGet]
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> result = (List<Patient>)_patientController.GetAll();

            return result;
        }

    }
}
