using PSW_Pharmacy_Adapter.Service;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using PSW_Pharmacy_Adapter.Dto;

namespace ServiceTests.Pharmacy_Adapter_Tests
{
    public class SftpTests
    {
        private const string EXISTING_PATH = @"../../../../PSW_Pharmacy_Adapter/wwwroot/test.html";
        private const string UNEXISTING_PATH = @"../../../PSW_Pharmacy_Adapter/wwwroot/unexisting.html";
        private const string PRESCRIPTION_PATH = @"../../../../PSW_Pharmacy_Adapter/wwwroot/prescription.txt";

        [Fact]
        public void Send_File_Successfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));
            bool Successfull = service.UploadFileToSftpServer(EXISTING_PATH);

            Successfull.ShouldBeTrue();
        }

        [Fact]
        public void Send_File_Unsuccessfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));

            bool Unsuccessfull = service.UploadFileToSftpServer(UNEXISTING_PATH);

            Unsuccessfull.ShouldBeFalse();
        }

        [Fact]
        public void Send_Prescription_Successfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));

            bool Successfull = service.SendPrescriptionfile(CreatePrescription(), PRESCRIPTION_PATH);

            Successfull.ShouldBeTrue();

        }

        private EPrescriptionDto CreatePrescription()
            => new EPrescriptionDto("Pera Peric",
                        124563987L,
                        DateTime.Now,
                        DateTime.Now.AddDays(30),
                        new List<MedicineDto>() {
                        new MedicineDto("Brufen", 1L, 15)
                        });


    }
}
