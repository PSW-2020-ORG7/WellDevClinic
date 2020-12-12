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
        /// <summary>
        ///calls GetAll() method from class PrescriptionController 
        ///so it can get all prescriptions from database
        /// </summary>
        /// <returns>status 200 OK response with a list of prescriptions</returns>
        [HttpGet]
        public IEnumerable<Prescription> GetAllPrescription()
        {
            List<Prescription> result = (List<Prescription>)_prescriptionController.GetAll();

            return result;
        }
    }
}
