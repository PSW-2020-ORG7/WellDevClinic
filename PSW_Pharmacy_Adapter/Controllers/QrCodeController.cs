using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpPost]
        public IActionResult Index(string inputText)
        {
            using (MemoryStream memoryStream = new MemoryStream()) 
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);
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
