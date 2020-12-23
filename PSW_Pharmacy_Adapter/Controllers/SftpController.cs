using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Service;
using Renci.SshNet;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        private readonly SftpService _sftpService;
        private const string PRESCRIPTION_PATH = @"wwwroot/Prescription.txt";

        public SftpController() 
        {
            _sftpService = new SftpService(new SftpClient("192.168.1.3", 22, "user", "password"));
        }

        [HttpPost]
        [Route("sendPrescription")]
        public IActionResult SendPrescriptionFile(EPrescriptionDto prescription)
        {
            int code = _sftpService.SendPrescriptionfile(prescription, PRESCRIPTION_PATH);
            if (code == -2)
                return NotFound();
            else if (code == -1)
                return StatusCode(503, Global.ErrorSftp);       //TODO A3: Srediti kodove gresaka
            return Ok();
        }
    }
}
