using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using System.Collections.Generic;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private IDrugController _drugController;

        public DrugController(IDrugController drugController)
        {
            _drugController = drugController;
        }

        /// <summary>
        ///calls GetAll() method from class Drugontroller 
        ///so it can get all drugs from database
        /// </summary>
        /// <returns>status 200 OK response with a list of drugs</returns>
        [HttpGet]
        public IEnumerable<Drug> GetAllDrug()
            => (List<Drug>)_drugController.GetAll();

        [HttpGet]
        [Route("{id?}")]
        public Drug GetDrug(long id)
            => _drugController.Get(id);

    }
}
