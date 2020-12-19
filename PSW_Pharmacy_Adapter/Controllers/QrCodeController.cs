using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
        public IActionResult Generate(string qrText)
            => File(_qrCodeService.Generate(qrText), "image/jpeg");

    }
}
