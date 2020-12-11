using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> getHospitalsMedicationStockAsync()
            => Ok(await _medicationService.GetAllMedication());
        
    }
}
