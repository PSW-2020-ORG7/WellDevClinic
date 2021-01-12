using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController : ControllerBase
    {
        private readonly GrpcClientService _serviceGrpc;
        private readonly IMedicationService _medicationService;

        public GrpcController(IMedicationService medicationService) 
        {
            _serviceGrpc = new GrpcClientService();
            _medicationService = medicationService;
        }


        [HttpGet]
        [Route("medications/{pharmacyname?}")]
        public async Task<IActionResult> GetAllMedicationsAmount(string pharmacyname)
        {
            List<Medication> meds = await _serviceGrpc.GetAllMedicationsAmount(pharmacyname);
            //List<MedicationDto> meds = await _medicationService.GetAllPharmacyMedications(pharmacyname);
            if (meds != null)
                return Ok(meds);
            return StatusCode(408, Global.ErrorMessage);
        }


        [HttpGet]          
        [Route("available/{medicationName?}/{pharmacyName?}")]
        public async Task<IActionResult> GetMedicationAmount(string medicationName, string pharmacyName)
        {
            int amount = await _serviceGrpc.GetMedicationAmount(medicationName, pharmacyName);
            //MedicationDto med = await _medicationService.GetPharmacyMedication(pharmacyName, medicationName);
            //int amount = med.Amount;
            if(amount >= -1)
                return Ok(amount);
            return StatusCode(408, Global.ErrorMessage);
        }
    }
}
