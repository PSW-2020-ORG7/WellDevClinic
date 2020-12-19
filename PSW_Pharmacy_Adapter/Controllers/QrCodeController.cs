using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Service.Iabstract;

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

        [HttpGet]
        [Route("{qrText?}")]
        public IActionResult Generate(string qrText)
            => File(_qrCodeService.Generate(qrText), "image/jpeg");

    }
}
