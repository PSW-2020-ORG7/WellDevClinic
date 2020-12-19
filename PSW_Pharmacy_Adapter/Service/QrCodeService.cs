using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using QRCoder;

namespace PSW_Pharmacy_Adapter.Service
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] Generate(string qrText)
        {
            //string input = "Marko Markovic" + "\n" + "5472012479531" + "\n" + DateTime.Today.ToShortDateString() + "\n" + "brufen" + "\n" + "3";
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitmap = qrCode.GetGraphic(5);
            byte[] bytes = BitmapToBytes(bitmap);

            return bytes;
        }

        private static Byte[] BitmapToBytes(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
