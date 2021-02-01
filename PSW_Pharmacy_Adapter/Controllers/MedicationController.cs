using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Mapping;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly IPharmacyMedicationService _medicationService;
        private readonly IHospitalMedicationService _hospitalService;
        private readonly GrpcMedicationService _grpcService;

        public MedicationController(IPharmacyMedicationService medicationService, IHospitalMedicationService hospitalService) 
        {
            _medicationService = medicationService;
            _hospitalService = hospitalService;
            _grpcService = new GrpcMedicationService();
        }

        [HttpGet]
        public async Task<IActionResult> GetHospitalMedicationStockAsync()
            => Ok(await _hospitalService.GetAllHospitalMedications());

        [HttpGet]
        [Route("hospital/{id?}")]
        public async Task<IActionResult> GetHospitalMedicationAsync(long id)
            => Ok(await _hospitalService.GetHospitalMedication(id));

        [HttpPost]
        [Route("findMedPh")]
        public async Task<IActionResult> GetPharmacyByMedicationAsync([FromBody]Medication medication)
        {
            List<PharmacyMedicationDto> result = await _medicationService.GetPharmacyByMedicationAsync(medication);
            if(result != null)
                return Ok(result);
            return StatusCode(408, "No pharmacy has responded to request! Try again later.");
        }         

        [HttpPost]
        [Route("findMedsPh")]
        public async Task<IActionResult> GetPharmacyByMedicationsAsync([FromBody] List<Medication> medications)
            => Ok(await _medicationService.GetPharmacyByMedicationsAsync(medications));


        [HttpGet]
        [Route("{pharmacyname?}")]
        public async Task<IActionResult> GetPharmacyMedications(string pharmacyname) 
        {
            List<Medication> meds = new List<Medication>();
            try
            {
                meds = await _grpcService.GetAllMedicationsAmount(pharmacyname);
            }
            catch {
                meds =  MedicationMapper.MapMedicationList(await _medicationService.GetAllPharmacyMedications(pharmacyname));
            }

            if (meds != null)
                return Ok(meds);
            return StatusCode(408, Global.ErrorMessage);
        }

        [HttpGet]
        [Route("available/{medicationName?}/{pharmacyName?}")]
        public async Task<IActionResult> GetMedicationAmount(string medicationName, string pharmacyName)
        {
            int amount = -408;
            try
            {
                amount = await _grpcService.GetMedicationAmount(medicationName, pharmacyName);
            }
            catch {
                MedicationDto med = await _medicationService.GetPharmacyMedication(pharmacyName, medicationName);
                amount = med.Amount;
            }
            
            if (amount >= -1)
                return Ok(amount);
            return StatusCode(408, Global.ErrorMessage);
        }


        [HttpGet]
        [Route("orderMedicine")]
        public async Task<IActionResult> OrderMedication([FromQuery] string phName, [FromQuery]string medName, [FromQuery]int amount)
        {
            Medication orderedMedication = await _medicationService.OrderMedicationAsync(phName, medName, amount);
            if (orderedMedication != null)
                return Ok(orderedMedication);
            return BadRequest("There is no such amount of desired medication at the pharmacy");
        }

        [HttpPost]
        [Route("orderMedicines")]
        public async Task<IActionResult> OrderMedication([FromQuery] string phName, [FromBody] List<MedicationOrderDto> order)
        {
            List<Medication> orderedMedications = new List<Medication>();
            try
            {
                orderedMedications = await _medicationService.OrderMedicationsAsync(phName, order);
            }
            catch {
                orderedMedications = await _grpcService.GetOrderedMeds(phName, order);
            }
            if (orderedMedications != null)
                return Ok(orderedMedications);
            return BadRequest("No medications can be ordered. (Pharmacy out of stock)");
        }

        [HttpGet]
        [Route("check/{id?}")]
        public IActionResult CheckStrucutre(string id)
            => Ok(_medicationService.GetUnsyncedMedicationsAsync(id));
    }
}
