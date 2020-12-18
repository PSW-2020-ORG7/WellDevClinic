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
    public class QrCodeController : Controller
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeController(IQrCodeService qrCodeService) 
        {
            _qrCodeService = qrCodeService;
        }

        [HttpGet]
        public IActionResult Generate(string input)
        {
            //string input = "Marko Markovic" + "\n" + "5472012479531" + "\n" + DateTime.Today.ToShortDateString() + "\n" + "brufen" + "\n" + "3";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitmap = qrCode.GetGraphic(5))
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
