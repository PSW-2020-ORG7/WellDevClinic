using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetHospitalsPrescriptionsStockAsync()
            => Ok(await _prescriptionService.GetAllPrescriptions());

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetPrescription(long id)
            => Ok(await _prescriptionService.GetPrescription(id));

    }
}

