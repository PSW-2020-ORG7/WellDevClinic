using PSW_Pharmacy_Adapter.Dto;
using Renci.SshNet;
using System;
using System.IO;


namespace PSW_Pharmacy_Adapter.Service
{
    public class SftpService
    {

        private readonly SftpClient _sftpClient;
        

        public SftpService(SftpClient sftpClient)
        {
            _sftpClient = sftpClient;
        }

        public bool UploadFileToSftpServer(string filePath)
        {
            _sftpClient.Connect();
            try
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    _sftpClient.UploadFile(stream, Path.GetFileName(filePath));
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
                return false;
            }
            _sftpClient.Disconnect();
            return true;
            
        }

        public bool SendPrescriptionfile(EPrescriptionDto prescription, string path)
        {
            //if (File.Exists(PRESCRIPTION_PATH))
            //{
                using (StreamWriter file = new StreamWriter(path, false))
                {
                    file.WriteLine(prescription.PatientName + "\n" + prescription.Jmbg + "\n" + prescription.StartTime.ToShortDateString());
                    foreach (MedicineDto m in prescription.Medicines)
                        file.WriteLine(m.Name + "\n" + m.Amount);
                }
            //}
            return UploadFileToSftpServer(path);
        }

    }
}
