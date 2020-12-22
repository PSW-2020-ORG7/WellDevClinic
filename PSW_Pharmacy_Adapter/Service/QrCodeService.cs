using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using QRCoder;

namespace PSW_Pharmacy_Adapter.Service
{
    public class QrCodeService : IQrCodeService
    {
        private const string SAVE_PATH = @"wwwroot/images/qrCodes/";
        public byte[] Generate(Prescription pre)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(GenerateQRtext(pre), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitmap = qrCode.GetGraphic(5);
            byte[] bytes = BitmapToBytes(bitmap);
            SaveFile(bytes, pre.Id.ToString());

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
            using var ms = new MemoryStream(array);
            using var fs = new FileStream(SAVE_PATH + "pre" + fileName + "qr.png", FileMode.Create);
            ms.WriteTo(fs);
        }

        private static string GenerateQRtext(Prescription pre)
        {
            string text = "Name: " + pre.CurrentPatient.Name + " " + pre.CurrentPatient.Lastname
                + ", JMBG: " + pre.CurrentPatient.Jmbg + ", StartDate: " + pre.Period.StartDate
                + ", EndDate: " + pre.Period.EndDate + ", Medicines: ";
            if (pre.Medication != null)
                foreach (Medication med in pre.Medication)
                    text += med.Name + ": " + med.Amount + ", ";
            return text;
        }
    }
}
