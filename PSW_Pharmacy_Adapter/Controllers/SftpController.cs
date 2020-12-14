using System;
using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Service;
using Renci.SshNet;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        private readonly SftpService _sftpService;

        public SftpController() 
        {
            _sftpService = new SftpService(new SftpClient("192.168.1.12", 22, "tester", "password"));
        }

        [Route("sendReport")]
        public bool UploadFileToSftpServer(String path)
        {
            path = @"wwwroot/primer.txt";
            return _sftpService.UploadFileToSftpServer( path);
        }

    }
}
