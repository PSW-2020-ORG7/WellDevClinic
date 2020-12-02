﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterlayerController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private bolnica.Controller.IDrugController _drugController = new bolnica.Controller.DrugController();

        /// <summary>
        ///calls GetAll() method from class Drugontroller 
        ///so it can get all drugs from database
        /// </summary>
        /// <returns>status 200 OK response with a list of drugs</returns>
        [HttpGet]
        public IEnumerable<Drug> GetAllDrug()
        {
            List<Drug> result = (List<Drug>)_drugController.GetAll();

            return result;
        }
    }
}
