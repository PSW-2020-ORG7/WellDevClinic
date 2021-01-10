using bolnica.Model.Dto;
using bolnica.Repository;
using bolnica.Service;
using Model.Director;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Moq;
using Repository;
using Service;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Graphic_Editor_Tests
{
   public class ExaminationTests
    {

        private static IBusinessDayRepository CreateBusinessDayRepository()
        {
            var stubRepository = new Mock<IBusinessDayRepository>();
            List<BusinessDay> businessDays = new List<BusinessDay>();

            Doctor doctor = new Doctor() { Id = 1, FirstName = "ivan", LastName = "ivanovic", };

            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);
            Room room = new Room();
            List<Period> periods = new List<Period>();
            periods.Add(period);

            BusinessDay businessDay = new BusinessDay(909, period, doctor, room, periods);

            businessDays.Add(businessDay);
            stubRepository.Setup(r => r.GetAllEager()).Returns(businessDays);
            return stubRepository.Object;
        }

        private static IExaminationPreviousRepository CreateStubRepositoryExaminationPrevious()
        {
            var stubRepository = new Mock<IExaminationPreviousRepository>();


            Patient patient = new Patient(1, "Pera", "Peric");
            Doctor doctor = new Doctor(2, "Eva", "Evic");
            DateTime start = new DateTime(2021, 1, 1);
            DateTime end = new DateTime(2021, 1, 2);
            Period period = new Period(start, end);
            Examination examination = new Examination(1, patient, doctor, period);



            return stubRepository.Object;
        }


        private static IDoctorRepository CreateDoctorRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();

            Doctor doctor = new Doctor(1, "ivan", "ivanovic");
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Room room = new Room();
            Period period = new Period(start, end);
            List<Period> periods = new List<Period>();
            periods.Add(period);

            BusinessDay businessDay = new BusinessDay(909, period, doctor, room, periods);

            List<BusinessDay> businessDays = new List<BusinessDay>();
            businessDays.Add(businessDay);
            doctor.BusinessDay = businessDays;
            stubRepository.Setup(r => r.GetEager(1)).Returns(doctor);
            return stubRepository.Object;
        }

        static Period period;
        private static IExaminationUpcomingRepository CreateStubRepositoryExaminationUpcoming()
        {
            var stubRepository = new Mock<IExaminationUpcomingRepository>();

            Patient patient = new Patient(7, "Ana", "Ivanovic");
            Doctor doctor = new Doctor(1, "ivan", "ivanovic");
            DateTime start = new DateTime(2021, 1, 10);
            DateTime end = new DateTime(2021, 1, 11);

            period = new Period(start, end);
            Examination examination = new Examination(1, patient, doctor, period);

            stubRepository.Setup(r => r.Save(doctor.Id, period, patient.Id)).Returns(examination);

            return stubRepository.Object;
        }

        private static IExaminationUpcomingRepository CreateStubRepositoryExaminationUpcoming2()
        {
            var stubRepository = new Mock<IExaminationUpcomingRepository>();
            var examinations = new List<Examination>();

            Patient patient = new Patient(7, "Ana", "Ivanovic");
            Doctor doctor = new Doctor(1, "ivan", "ivanovic");
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);
            Examination examination1 = new Examination(1, patient, doctor, period);

            examinations.Add(examination1);


            stubRepository.Setup(r => r.GetAllEager()).Returns(examinations);
            return stubRepository.Object;
        }

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
        public void GetSpecialityExist()
        {
            
            var specialityStubRepository = new Mock<ISpecialityRepository>();

            Speciality speciality = new Speciality(921, "pedijatar");
            Speciality speciality1 = new Speciality(922, "ginekolog");
            List<Speciality> specs = new List<Speciality>();

            specs.Add(speciality);
            specs.Add(speciality1);



            specialityStubRepository.Setup(r => r.GetEager()).Returns(specs);

            SpecialityService specialityService = new SpecialityService(specialityStubRepository.Object);
            List<Speciality> returnedSpeciality = specialityService.GetAll() as List<Speciality>;

            returnedSpeciality.ShouldBeEquivalentTo(specs);


        }
     
        [Fact]
        public void GetOneDoctorNonExist()
        {
            var doctorStubRepository = new Mock<IDoctorRepository>();

            DoctorService doctorService = new DoctorService(doctorStubRepository.Object);
            Doctor returnedDoctor = doctorService.Get(903);

            returnedDoctor.ShouldBeNull();
        }


        [Fact]
        public void Get_business_days()
        {
            BusinessDayService service = new BusinessDayService((IBusinessDayRepository)CreateBusinessDayRepository(), new DoctorService(CreateDoctorRepository()));
            List<BusinessDay> result = (List<BusinessDay>)service.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Get_terms()
        {


            var doctorBusinessDayRepository = CreateBusinessDayRepository();
            var doctorRepository = CreateDoctorRepository();

            List<BusinessDay> businessDays = new List<BusinessDay>();

            DoctorService doc = new DoctorService(doctorRepository);
            BusinessDayService service = new BusinessDayService(doctorBusinessDayRepository, doc);
            Doctor doctor = new Doctor(1, "ivan", "ivanovic");

            DateTime start = DateTime.Now.AddMinutes(5);
            DateTime end = start.AddDays(1);
            Period period = new Period(start, end);

            PriorityType priority = PriorityType.NoPriority;
            BusinessDayDTO businessDay = new BusinessDayDTO(doctor, period, priority);
            List<ExaminationDTO> result = service.Search(businessDay);
            result.ShouldNotBeEmpty();

        }

        [Fact]
        public void Getting_all_upcoming_examinations()
        {
            ExaminationService examinationService = new ExaminationService(CreateStubRepositoryExaminationUpcoming2(), null);

            List<Examination> returnedExaminations = (List<Examination>)examinationService.GetAll();

            returnedExaminations.ShouldNotBeEmpty();
        }

        [Fact]
        public void New_Examination()
        {
            var upcomingRepository = CreateStubRepositoryExaminationUpcoming();
            var previousRepository = CreateStubRepositoryExaminationPrevious();

            ExaminationService service = new ExaminationService(upcomingRepository, previousRepository);

            Patient patient = new Patient(7, "Ana", "Ivanovic");
            Doctor doctor = new Doctor(1, "ivan", "ivanovic");


            Examination result = service.NewExamination(doctor.Id, period, patient.Id);


            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_Examination()
        {
            var stubService = new Mock<IExaminationService>();
            Patient patient = new Patient(7, "Ana", "Ivanovic");
            Doctor doctor = new Doctor(1, "ivan", "ivanovic");
            DateTime start = new DateTime(2021, 1, 10);
            DateTime end = new DateTime(2021, 1, 11);
            period = new Period(start, end);
            Examination examination = new Examination(1, patient, doctor, period);

            stubService.Object.Edit(examination);

            stubService.Verify(x => x.Edit(It.IsAny<Examination>()), Times.AtLeastOnce);
        }

    }
}
