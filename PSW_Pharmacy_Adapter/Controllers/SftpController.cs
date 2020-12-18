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
            _sftpService = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));
        }

        [Route("sendPrescription")]
        public bool SendPrescriptionFile(EPrescriptionDto prescription)
            => _sftpService.SendPrescriptionfile(prescription, PRESCRIPTION_PATH);

    }
}
