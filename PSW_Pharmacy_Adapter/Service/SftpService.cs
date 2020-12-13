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

        public bool UploadFileToSftpServer(String sourceFile)
        {
            
            _sftpClient.Connect();
            try
            {
                using (Stream stream = File.OpenRead(sourceFile))
                {
                    _sftpClient.UploadFile(stream, Path.GetFileName(sourceFile));
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
