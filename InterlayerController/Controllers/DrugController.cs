using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using System.Collections.Generic;
using System.Linq;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IDrugController _drugController;
        private readonly IPrescriptionController _prescriptionController;
        private readonly IExaminationController _examinationController;

        public DrugController(IDrugController drugController, IExaminationController examinationController, IPrescriptionController prescriptionController)
        {
            _drugController = drugController;
            _examinationController = examinationController;
            _prescriptionController = prescriptionController;
        }

        /// <summary>
        ///calls GetAll() method from class Drugontroller 
        ///so it can get all drugs from database
        /// </summary>
        /// <returns>status 200 OK response with a list of drugs</returns>
        [HttpGet]
        public IEnumerable<Drug> GetAllDrug()           // TODO A: Vrati samo prihvacene lekove!
            => (List<Drug>)_drugController.GetAll();

        /// <summary>
        /// Filters drugs from database to
        /// return only non-prescribed ones
        /// </summary>
        /// <returns>status 200 OK response with a list of non-prescribed drugs</returns>
        [HttpGet]
        [Route("medicationStock")]
        public IEnumerable<Drug> GetMedicationStock()
        {
            List<Drug> notPrescribed = new List<Drug>();
            List<Drug> prescribed = new List<Drug>();
            foreach (Examination e in _examinationController.GetAllPrevious())
                prescribed.AddRange(_prescriptionController.Get(e.Prescription.Id).Drug);
            foreach (Drug d in _drugController.GetAll())
                if (!prescribed.Select(x => x.Id).Contains(d.Id))
                    notPrescribed.Add(d);
            return notPrescribed;
        }
            

        [HttpGet]
        [Route("{id?}")]
        public Drug GetDrug(long id)
            => _drugController.Get(id);

        [HttpPut]
        public Drug Save([FromBody]Drug d)
            => _drugController.Save(d);

    }
}
