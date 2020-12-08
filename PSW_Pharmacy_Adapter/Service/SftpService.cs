using PSW_Pharmacy_Adapter.Model;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            catch
            {
                return false;
            }
            _sftpClient.Disconnect();
            return true;
            
        }

    }
}
