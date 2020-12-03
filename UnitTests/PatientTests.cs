using System.Collections.Generic;
using System.Linq;
using Xunit;
using bolnica.Model;
using Model.Users;
using Repository;
using bolnica.Repository;
using bolnica.Service;
using Moq;
using System;

namespace UnitTests
{
    public class PatientTests
    {

        [Fact]
        public void GetEager_Patient()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);

            patientStubRepository.Setup(r => r.Get(0)).Returns(patient);

            PatientService patientService = new PatientService(patientStubRepository.Object, null);

            Patient p = patientService.Get(0);
            Assert.NotNull(p);

        }

        [Fact]
        public void Save_Patient()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            var patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);

            patientStubRepository.Setup(r => r.Save(patient)).Returns(patient);

            PatientService patientService = new PatientService(patientStubRepository.Object, null);

            Patient p = patientService.Save(patient);
            Assert.Null(p);

        }

        [Fact]
        public void Finds_patient_with_same_jmbg()
        {
            var stubRepository = new Mock<bolnica.Repository.IPatientRepository>();

            Patient patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);
            Patient patient2 = new Patient(0, "Marko", "Petar", "Markovic", "2222222", "marko22.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);

            stubRepository.Setup(m => m.GetPatientByJMBG("1111111")).Returns(patient);

            bolnica.Service.PatientService service = new bolnica.Service.PatientService(stubRepository.Object);

            Patient p = service.CheckExistence("1111111", "proba", "proba");
            Assert.NotNull(p);
        }

        [Fact]
        public void Finds_patient_with_same_username()
        {
            var stubRepository = new Mock<bolnica.Repository.IPatientRepository>();

            Patient patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);
            Patient patient2 = new Patient(0, "Marko", "Petar", "Markovic", "2222222", "marko22.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);

            stubRepository.Setup(m => m.GetPatientByUsername("proba")).Returns(patient);

            bolnica.Service.PatientService service = new bolnica.Service.PatientService(stubRepository.Object);

            Patient p = service.CheckExistence("1111111", "proba", "proba");
            Assert.NotNull(p);
        }

        [Fact]
        public void Finds_patient_with_same_email()
        {
            var stubRepository = new Mock<bolnica.Repository.IPatientRepository>();

            Patient patient = new Patient(0, "Marko", "Petar", "Markovic", "1111111", "marko.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);
            Patient patient2 = new Patient(0, "Marko", "Petar", "Markovic", "2222222", "marko22.markovic@gmail.com", new DateTime(2001, 1, 1), null, null, "proba", "proba", true, null, "muski", false, "azijat", "A+", "22", null);

            stubRepository.Setup(m => m.GetPatientByMail("proba")).Returns(patient);

            bolnica.Service.PatientService service = new bolnica.Service.PatientService(stubRepository.Object);

            Patient p = service.CheckExistence("1111111", "proba", "proba");
            Assert.NotNull(p);
        }

    }
}
