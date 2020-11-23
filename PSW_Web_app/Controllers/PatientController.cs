using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Users;

namespace PSW_Web_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private bolnica.Controller.IPatientController _patientController = new bolnica.Controller.PatientController();

        [HttpGet]
        public Patient GetPatientById(long id)
        {
            Patient patient = _patientController.Get(id);
            return patient;
        }
    }
}