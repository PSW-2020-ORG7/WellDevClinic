using Model.Doctor;
using Model.Users;
using Moq;
using Repository;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Graphic_Editor_Tests
{
   public class ExaminationTests
    {

        [Fact]
        public void GetAllDoctorsExist()

        {

            var doctorStubRepository = new Mock<IDoctorRepository>();

            List<Doctor> doctors = new List<Doctor>();

            State state = new State(904, "Serbia", "1");
            Town town = new Town(905, "Novi Sad", "21000", state);
            Address address = new Address(903, "Kisacka", 5, town);
            Speciality specialty = new Speciality(902, "Opsta praksa");
            Speciality specialty1 = new Speciality(992, "Pedijatar");


            Doctor doctor = new Doctor(902, "Ivan", "Ivanovic", "1234567812345", "ivan@ivanovic.com", "065-234/344", new DateTime(1975 - 12 - 21), address, "ivan", "ivan", null, specialty);
            Doctor doctor1 = new Doctor(992, "Pera", "Peric", "1234567851234", "pera@peric.com", "066-224/221", new DateTime(1955 - 12 - 21), address, "pera", "pera", null, specialty1);

            doctors.Add(doctor);

            doctorStubRepository.Setup(r => r.GetAllEager()).Returns(doctors);

            DoctorService doctorService = new DoctorService(doctorStubRepository.Object);

            List<Doctor> returnedDoctor = doctorService.GetAll() as List<Doctor>;
            returnedDoctor.ShouldBeEquivalentTo(doctors);

        }

        [Fact]
        public void GetOneDoctorNonExist()
        {
            var doctorStubRepository = new Mock<IDoctorRepository>();

            DoctorService doctorService = new DoctorService(doctorStubRepository.Object);
            Doctor returnedDoctor = doctorService.Get(903);

            returnedDoctor.ShouldBeNull();
        }
    }
}
