using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionController _prescriptionController;

        public PrescriptionController(IPrescriptionController prescriptionController)
        {
            _prescriptionController = prescriptionController;
        }

        [HttpGet]
        [Route("{id?}")]
        public Prescription GetPrescription(long id)
        {
            Prescription result = (Prescription)_prescriptionController.Get(id);
            foreach (Drug d in result.Drug)
                if (d.Alternative != null)
                    foreach (Drug alter in d.Alternative)
                        alter.Alternative = null;
            return result;
        }

        /// <summary>
        ///calls GetAll() method from class PrescriptionController 
        ///so it can get all prescriptions from database
        /// </summary>
        /// <returns>status 200 OK response with a list of prescriptions</returns>
        [HttpGet]
        public IEnumerable<Prescription> GetAllPrescription()
        {
            List<Prescription> result = (List<Prescription>)_prescriptionController.GetAll();
            foreach (Prescription p in result)  
                foreach (Drug d in p.Drug)
                    if (d.Alternative != null)
                        foreach (Drug alter in d.Alternative)
                            alter.Alternative = null;
            return result;
        }
    }
}
