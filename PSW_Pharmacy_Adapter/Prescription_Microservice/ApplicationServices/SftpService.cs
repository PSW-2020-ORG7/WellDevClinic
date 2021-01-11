using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Dto;
using Renci.SshNet;
using System;
using System.IO;
using System.Net.Sockets;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.ApplicationServices
{
    public class SftpService
    {

        private readonly SftpClient _sftpClient;
        

        public SftpService(SftpClient sftpClient)
        {
            _sftpClient = sftpClient;
        }

        public int UploadFileToSftpServer(string filePath)
        {
            try
            {
                _sftpClient.Connect();
                using (Stream stream = File.OpenRead(filePath))
                {
                    _sftpClient.UploadFile(stream, Path.GetFileName(filePath));
                }
                _sftpClient.Disconnect();
            }
            catch(SocketException e)
            {
                Console.Write(e);
                return -1;
            }
            catch
            {
                return -2;
            }
            
            return 1;
            
        }

        public int SendPrescriptionfile(EPrescriptionDto prescription, string path)
        {
            if (!File.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(prescription.PatientName);
                file.WriteLine(prescription.Jmbg);
                file.WriteLine(prescription.StartTime.ToShortDateString());
                foreach (MedicationDto m in prescription.Medicines)
                    file.WriteLine(m.Name + ":" + m.Amount);
                file.WriteLine("*");
            }
            return UploadFileToSftpServer(path);
        }

    }
}
