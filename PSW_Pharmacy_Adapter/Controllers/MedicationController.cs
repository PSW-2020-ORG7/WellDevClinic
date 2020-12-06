using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {

        private readonly MedicationService _medicationService;

        public MedicationController(MedicationService medicationService) 
        {
            _medicationService = medicationService;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getHospitalsMedicationStockAsync()
        {
            return Ok(await _medicationService.GetAllMedication());
        }
    }
}
