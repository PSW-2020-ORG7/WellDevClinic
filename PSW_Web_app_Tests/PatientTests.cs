
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Controllers;
using Xunit;
using Moq;
using Repository;
using bolnica.Service;
using Service;

namespace PSW_Web_app_Tests
{
    public class PatientTests
    {
        [Fact]
        public void Getting_patient()
        {
            var stubRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>();

            Patient patient = new Patient(1, "Andjela", "Petrovic", "100299755888", "andjela@gmail.com", "062210653");
            patients.Add(patient);

            stubRepository.Setup(m=>m.GetAll()).Returns(patients);

            PatientService patientService = new PatientService(stubRepository.Object);
            Patient result = patientService.Get(1);

            Assert.NotNull(result);
        }
    }
}
