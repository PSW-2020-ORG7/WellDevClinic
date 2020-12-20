using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using QRCoder;

namespace PSW_Pharmacy_Adapter.Service
{
    public class QrCodeService : IQrCodeService
    {
        private const string SAVE_PATH = @"wwwroot/images/qrCodes/";
        public byte[] Generate(string qrText)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitmap = qrCode.GetGraphic(5);
            byte[] bytes = BitmapToBytes(bitmap);
            SaveFile(bytes, qrText.Substring(0, 3));   //TODO: srediti da se samo id prosledjuje

            return bytes;
        }

        private static byte[] BitmapToBytes(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private static void SaveFile(byte[] array, string fileName)
        {
            using (var ms = new MemoryStream(array))
            {
                using (var fs = new FileStream(SAVE_PATH + "pre" + fileName + "qr.png" , FileMode.Create))
                {
                    ms.WriteTo(fs);
                }
            }
        }
    }
}
