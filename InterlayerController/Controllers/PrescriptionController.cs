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
            foreach (Examination e in _examinationController.GetAll())
                if (e.Prescription.Id == id)
                {
                    foreach (Drug d in e.Prescription.Drug)
                        if (d.Alternative != null)
                            foreach (Drug alter in d.Alternative)
                                alter.Alternative = null;
                    return PrescriptionAdapter.ExaminationToPatientPrescriptionDto(e);
                }
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
            foreach(Examination e in _examinationController.GetAll())
            {
                foreach (Drug d in e.Prescription.Drug)
                    if (d.Alternative != null)
                        foreach (Drug alter in d.Alternative)
                            alter.Alternative = null;
                prescriptions.Add(PrescriptionAdapter.ExaminationToPatientPrescriptionDto(e));
            }
                
            return prescriptions;
        }
    }
}
