using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using Moq;
using Repository;
using Service;

namespace ServiceTests
{
    public class AppointmentTests
    {
        [Fact]
        public void GetAll_Doctors_By_Specialty()
        {
            var doctorStubRepository = new Mock<IDoctorRepository>();
            List<Doctor> doctors = new List<Doctor>();
            Doctor d1 = new Doctor(1, "Petar", "Petrovic", "1111111111111", "petar@gmail.com", "021-111-111", new DateTime(1970,6,10,0,0,0,0), null, null, null, null, new Speciality("Ortopedija"));
            Doctor d2 = new Doctor(2, "Marko", "Markovic", "2222222222222", "marko@gmail.com", "021-111-111", new DateTime(1970,6,10,0,0,0,0), null, null, null, null, new Speciality("Neurohirurgija"));
            doctors.Add(d1);
            doctors.Add(d2);

            doctorStubRepository.Setup(r => r.GetAllEager()).Returns(doctors);

            DoctorService doctorService = new DoctorService(doctorStubRepository.Object);

            List<Doctor> returnedDoctors = doctorService.GetDoctorsBySpeciality(new Speciality("Neurohirurgija"));

            Assert.Null(returnedDoctors);
        }

    }
}
