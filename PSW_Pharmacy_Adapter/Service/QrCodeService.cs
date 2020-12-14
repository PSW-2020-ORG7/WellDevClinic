using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QRCoder;

namespace PSW_Pharmacy_Adapter.Service
{
    public class QrCodeService
    {
        public void Generate()
        {
            string input = "Marko Markovic" + "\n" + "5472012479531" + "\n" + DateTime.Today.ToShortDateString() + "\n" + "brufen" + "\n" + "3";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitmap = qrCode.GetGraphic(5))
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
 //                   ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }
}
