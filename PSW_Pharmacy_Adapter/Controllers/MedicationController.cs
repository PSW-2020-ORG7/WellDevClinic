using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService) 
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitalMedicationStockAsync()
            => Ok(await _medicationService.GetAllHospitalMedications());

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetHospitalMedicationAsync(long id)
            => Ok(await _medicationService.GetHospitalMedication(id));

        [HttpPost]
        [Route("findMedPh")]
        public async Task<IActionResult> GetPharmacyByMedicationAsync([FromBody]Medication medication)
            => Ok(await _medicationService.GetPharmacyByMedicationAsync(medication));

        [HttpPost]
        [Route("findMedsPh")]
        public async Task<IActionResult> GetPharmacyByMedicationsAsync([FromBody] List<Medication> medications)
            => Ok(await _medicationService.GetPharmacyByMedicationsAsync(medications));

        [HttpGet]
        [Route("orderMedicine")]
        public async Task<IActionResult> OrderMedication([FromQuery] string phName, [FromQuery]string medName, [FromQuery]int amount)
        {
            if(await _medicationService.OrderMedicationAsync(phName, medName, amount) != null)
                return Ok();
            return BadRequest();        // There is no such amount at pharmacy
        }

        [HttpPost]
        [Route("orderMedicines")]
        public async Task<IActionResult> OrderMedication([FromQuery] string phName, [FromBody] List<MedicationOrderDto> order)
        {
            List<Medication> response = await _medicationService.OrderMedicationsAsync(phName, order);
            if (response != null)
                return Ok(response);
            return BadRequest();        // No medications can be ordered
        }

        [HttpGet]
        [Route("check/{id?}")]
        public IActionResult CheckStrucutre(string id)
            => Ok(_medicationService.GetUnsyncedMedicationsAsync(id));
    }
}
