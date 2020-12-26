using bolnica.Repository;
using bolnica.Service;
using Model.Users;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Graphic_Editor_Tests
{
    public class PatientTests
    {

        private static IPatientRepository CreatePatientRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient("Ana", "Ivanovic", "1234567891230", "ana@ivanovic", "66999666", new DateTime(1975, 12, 21), false));

            stubRepository.Setup(m => m.GetEager()).Returns(patients);
            return stubRepository.Object;
        }

        [Fact]
        public void Get_all_patient_exists()
        {
            PatientService service = new PatientService(CreatePatientRepository());
            List<Patient> result = (List<Patient>)service.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Get_one_patient_non_exists()
        {

            PatientService service = new PatientService(CreatePatientRepository());
            List<Patient> result = (List<Patient>)service.GetAll();
            
            Patient p = service.Get(9);
            p.ShouldBeNull();
        }

        [Fact]
        public void Find_patient_through_jmbg()
        {
            var stubRepository = new Mock<bolnica.Repository.IPatientRepository>();

            Patient patient = new Patient("Ana", "Ivanovic", "1234567891230", "ana@ivanovic", "66999666", new DateTime(1975, 12, 21), false);

            stubRepository.Setup(m => m.GetPatientByJMBG("1234567891230")).Returns(patient);

            bolnica.Service.PatientService service = new bolnica.Service.PatientService(stubRepository.Object);

            Patient p = service.CheckExistence("1234567891230", "ana", "ana@ivanovic");
            Assert.NotNull(p);
        }

    }
}
