using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace WellDevCoreTests
{
    public class RegistrationTests
    {
        [Fact]
        public void Finds_patient_with_same_info()
        {
            var stubRepository = new Mock<bolnica.Repository.IPatientRepository>();

            Patient patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", "061-1111-111", new DateTime(2001, 1, 1), new Address(1, "Narodnog fronta", 3, new Town(2, "Novi Sad", "21000", new State(2, "Srbija", "2"))), "proba", "proba", "Srbija", "Novi Sad", "muski", "azijat", "A+", false, "22");
            Patient patient2 = new Patient(0, "Marko", "Petar", "Markovic", "2222222", "marko22.markovic@gmail.com", "061-1111-111", new DateTime(2001, 1, 1), new Address(1, "Narodnog fronta", 3, new Town(2, "Novi Sad", "21000", new State(2, "Srbija", "2"))), "proba2", "proba", "Srbija", "Novi Sad", "muski", "azijat", "A+", false, "11");

            stubRepository.Setup(m => m.GetPatientByJMBG("1111111")).Returns(patient);
            stubRepository.Setup(m => m.GetPatientByMail("marko.markovic@gmail.com")).Returns(patient);
            stubRepository.Setup(m => m.GetPatientByUsername("proba")).Returns(patient);

            bolnica.Service.PatientService service = new bolnica.Service.PatientService(stubRepository.Object);

            Patient p = service.Save(patient2);
            Assert.Null(p);
        }
    }
}
