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
        ClientService serviceGrpc;
        public GrpcController() 
        {
            serviceGrpc = new ClientService();
        }

        [HttpGet]          
        [Route("available/{medicationName?}/{pharmacyName?}")]
        public async Task<IActionResult> isAvailableMedication(string medicationName, string pharmacyName)     
            => Ok(await serviceGrpc.SendMessage(medicationName, pharmacyName));

        [HttpGet]
        [Route("medications/{pharmacyname?}")]
        public async Task<IActionResult> getMedications(string pharmacyname)
            => Ok(await serviceGrpc.getMedications(pharmacyname));

    }
}
