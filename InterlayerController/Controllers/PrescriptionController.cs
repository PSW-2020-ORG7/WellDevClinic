using System.Collections.Generic;
using bolnica.Controller;
using bolnica.Model.Adapters;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using WellDevCore.Model.dtos;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionController _prescriptionController;
        private readonly IExaminationController _examinationController;

        public PrescriptionController(IPrescriptionController prescriptionController, IExaminationController examinationController)
        {
            _prescriptionController = prescriptionController;
            _examinationController = examinationController;
        }

        [HttpGet]
        [Route("{id?}")]
        public PatientPrescriptionDTO GetPrescription(long id)
        {
            foreach (Examination e in _examinationController.GetAllPrevious())
                if (e.Prescription.Id == id)
                    return PrescriptionAdapter.ExaminationToPatientPrescriptionDto(e);
            return null;
        }

        /// <summary>
        ///calls GetAll() method from class ExaminationController 
        ///so it can get all prescriptions with patient who got the prescription from database
        /// </summary>
        /// <returns>status 200 OK response with a list of prescriptions</returns>
        [HttpGet]
        [Route("all")]
        public IEnumerable<PatientPrescriptionDTO> GetAllPrescription()
        {
            List<PatientPrescriptionDTO> prescriptions = new List<PatientPrescriptionDTO>();
            foreach(Examination e in _examinationController.GetAllPrevious())
                prescriptions.Add(PrescriptionAdapter.ExaminationToPatientPrescriptionDto(e));
            return prescriptions;
        }
    }
}
