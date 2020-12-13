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

        private static IDoctorRepository CreateRepository()
        {
            var doctorStubRepository = new Mock<IDoctorRepository>();
            List<Doctor> doctors = new List<Doctor>();
            Doctor d1 = new Doctor(1, "Petar", "Petrovic", "1111111111111", "petar@gmail.com", "021-111-111", new DateTime(1970, 6, 10, 0, 0, 0, 0), null, null, null, null, new Speciality("Ortopedija"));
            Doctor d2 = new Doctor(2, "Marko", "Markovic", "2222222222222", "marko@gmail.com", "021-111-111", new DateTime(1970, 6, 10, 0, 0, 0, 0), null, null, null, null, new Speciality("Neurohirurgija"));
            doctors.Add(d1);
            doctors.Add(d2);

            doctorStubRepository.Setup(r => r.GetAllEager()).Returns(doctors);

            return doctorStubRepository.Object;
        }

        private static ISpecialityRepository CreateRepositorySpec()
        {
            var specialityStubRepository = new Mock<ISpecialityRepository>();
            List<Speciality> specs = new List<Speciality>();
            Speciality s1 = new Speciality("Neurohirurgija");
            Speciality s2 = new Speciality("Stomatologija");
            Speciality s3 = new Speciality("Pedijatrija");
            specs.Add(s1);
            specs.Add(s2);
            specs.Add(s3);

            specialityStubRepository.Setup(r => r.GetEager()).Returns(specs);

            return specialityStubRepository.Object;
        }

        [Fact]
        public void GetAll_Doctors_By_Specialty()
        {
            DoctorService doctorService = new DoctorService(CreateRepository());
            
            List<Doctor> returnedDoctors = doctorService.GetDoctorsBySpeciality(new Speciality("Neurohirurgija"));

            Assert.NotEmpty(returnedDoctors);
        }

        [Fact]
        public void GetAll_Doctors_By_Specialty_Failed()
        {
            DoctorService doctorService = new DoctorService(CreateRepository());

            List<Doctor> returnedDoctors = doctorService.GetDoctorsBySpeciality(new Speciality("Stomatologija"));

            Assert.Empty(returnedDoctors);
        }

        [Fact]
        public void GetAll_Speciality()
        {
            SpecialityService specialityService = new SpecialityService(CreateRepositorySpec());

            List<Speciality> returnedSpeciality = (List<Speciality>)specialityService.GetAll();

            Assert.NotEmpty(returnedSpeciality);
        }

    }
}
