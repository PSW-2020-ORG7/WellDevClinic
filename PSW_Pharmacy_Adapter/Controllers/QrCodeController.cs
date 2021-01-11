using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeController(IQrCodeService qrCodeService) 
        {
            _qrCodeService = qrCodeService;
        }

        [HttpPost]
        [Route("eprescription")]
        public IActionResult Generate(Prescription prescription)
            => File(_qrCodeService.Generate(prescription), "image/jpeg");

    }
}
