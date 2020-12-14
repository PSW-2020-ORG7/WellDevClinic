using PSW_Pharmacy_Adapter.Dto;
using Renci.SshNet;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PSW_Pharmacy_Adapter.Service
{
    public class SftpService
    {

        private readonly SftpClient _sftpClient;

        public SftpService(SftpClient sftpClient)
        {
            _sftpClient = sftpClient;
        }

        public bool UploadFileToSftpServer(String path)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, false))
            {
                file.WriteLine("test123");
            }
            _sftpClient.Connect();
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    _sftpClient.UploadFile(stream, Path.GetFileName(path));
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

    }
}
