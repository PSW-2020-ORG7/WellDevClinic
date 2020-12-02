using PSW_Pharmacy_Adapter.Service;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Shouldly;
using Xunit;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class Sftp_Test
    {
        private const string EXISTING_PATH = @"../../../../PSW_Pharmacy_Adapter/wwwroot/index.html";
        private const string UNEXISTING_PATH = @"../../../PSW_Pharmacy_Adapter/wwwroot/unexisting.html";

        [Fact]
        public void sendFileSuccessfully()
        {

            SftpService service = new SftpService(new SftpClient("192.168.0.16", 22, "user", "password"));

            bool Successfull = service.UploadFileToSftpServer(EXISTING_PATH);

            Successfull.ShouldBeTrue();
        }

        [Fact]
        public void sendFileUnsuccessfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.0.16", 22, "user", "password"));

            bool Unsuccessfull = service.UploadFileToSftpServer(UNEXISTING_PATH);

            Unsuccessfull.ShouldBeFalse();
            
        }


    }
}
