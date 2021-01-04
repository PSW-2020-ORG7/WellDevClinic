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
            int Successfull = service.UploadFileToSftpServer(EXISTING_PATH);

            Successfull.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Send_File_Unsuccessfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));

            int Unsuccessfull = service.UploadFileToSftpServer(UNEXISTING_PATH);

            Unsuccessfull.ShouldBeEquivalentTo(-2);
        }

        [Fact]
        public void Send_Prescription_Successfully()
        {
            SftpService service = new SftpService(new SftpClient("192.168.1.4", 22, "user", "password"));

            int Successfull = service.SendPrescriptionfile(CreatePrescription(), PRESCRIPTION_PATH);

            Successfull.ShouldBeEquivalentTo(1);

        }

        private EPrescriptionDto CreatePrescription()
            => new EPrescriptionDto("Pera Peric",
                        "1245639870123",
                        DateTime.Now,
                        new List<MedicationDto>() {
                        new MedicationDto("Brufen", 1L, 15)
                        });


    }
}
