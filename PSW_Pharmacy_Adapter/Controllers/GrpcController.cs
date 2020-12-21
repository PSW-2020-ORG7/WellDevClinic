using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController : ControllerBase
    {
        private readonly ClientService _serviceGrpc;

        public GrpcController() 
        {
            _serviceGrpc = new ClientService();
        }

        [HttpGet]          
        [Route("available/{medicationName?}/{pharmacyName?}")]
        public async Task<IActionResult> IsAvailableMedication(string medicationName, string pharmacyName)     
            => Ok(await _serviceGrpc.SendMessage(medicationName, pharmacyName));

        [HttpGet]
        [Route("medications/{pharmacyname?}")]
        public async Task<IActionResult> GetMedications(string pharmacyname)
            => Ok(await _serviceGrpc.GetMedications(pharmacyname));

    }
}
