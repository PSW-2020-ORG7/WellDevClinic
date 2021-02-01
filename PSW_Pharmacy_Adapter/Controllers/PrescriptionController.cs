using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;
using Renci.SshNet;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IPrescriptionQrService _qrCodeService;
        private readonly PrescriptionTransferService _prescriptionTrnasferService;

        private const string PRESCRIPTION_PATH = @"wwwroot/Prescription.txt";
        private const string SFTP_HOST = "192.168.1.3";

        public PrescriptionController(IPrescriptionService prescriptionService, IPrescriptionQrService qrCodeService)
        {
            _prescriptionService = prescriptionService;
            _qrCodeService = qrCodeService;
            _prescriptionTrnasferService = new PrescriptionTransferService(new SftpClient(SFTP_HOST, 22, "user", "password"));
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetHospitalsPrescriptionsStockAsync()
            => Ok(await _prescriptionService.GetAllPrescriptions());

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetPrescription(long id)
            => Ok(await _prescriptionService.GetPrescription(id));

        [HttpPost]
        [Route("eprescription")]
        public IActionResult Generate(Prescription prescription)
            => File(_qrCodeService.Generate(prescription), "image/jpeg");

        [HttpPost]
        [Route("sendPrescription")]
        public IActionResult SendPrescriptionFile(EPrescriptionDto prescription)
        {
            int code = _prescriptionTrnasferService.SendPrescriptionfile(prescription, PRESCRIPTION_PATH);
            if (code == -2)
                return NotFound();
            else if (code == -1)
                return StatusCode(503, Global.ErrorSftp);
            return Ok();
        }
    }
}

