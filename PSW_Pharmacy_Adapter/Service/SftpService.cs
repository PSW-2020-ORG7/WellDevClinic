using PSW_Pharmacy_Adapter.Dto;
using Renci.SshNet;
using System;
using System.IO;
using System.Net.Sockets;

namespace PSW_Pharmacy_Adapter.Service
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
            //if (File.Exists(PRESCRIPTION_PATH))
            //TODO A1: Path not found exception
            using (StreamWriter file = new StreamWriter(path, false))
            {
                file.WriteLine(prescription.PatientName + "\n" + prescription.Jmbg + "\n" + prescription.StartTime.ToShortDateString() + "\n" + prescription.EndTime.ToShortDateString());
                foreach (MedicineDto m in prescription.Medicines)
                    file.WriteLine(m.Name + "\n" + m.Amount);
            }
            return UploadFileToSftpServer(path);
        }

    }
}
