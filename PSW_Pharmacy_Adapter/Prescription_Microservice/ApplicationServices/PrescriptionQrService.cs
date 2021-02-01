using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;
using QRCoder;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices
{
    public class PrescriptionQrService : IPrescriptionQrService
    {
        private const string SAVE_PATH = @"wwwroot/images/qrCodes/";
        public byte[] Generate(Prescription prescription)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(GenerateQRtext(prescription), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitmap = qrCode.GetGraphic(5);
            byte[] bytes = BitmapToBytes(bitmap);
            SaveFile(bytes, prescription.Id.ToString());

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
            if (!File.Exists(SAVE_PATH))
                Directory.CreateDirectory(SAVE_PATH);
            using var ms = new MemoryStream(array);
            using var fs = new FileStream(SAVE_PATH + "pre" + fileName + "qr.png", FileMode.Create);
            ms.WriteTo(fs);
        }

        private static string GenerateQRtext(Prescription pre)
        {
            string text = "Name: " + pre.PatFirstName + " " + pre.PatLastName
                + ", JMBG: " + pre.PatJmbg + ", StartDate: " + pre.TimePeriod.StartDate
                + ", Medicines: ";
            if (pre.Medications != null)
                foreach (Medication med in pre.Medications)
                    text += med.Name + ": " + med.Amount + ", ";
            return text;
        }
    }
}
