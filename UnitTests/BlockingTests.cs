using System;
using System.Collections.Generic;
using System.Text;
using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using Moq;
using Repository;
using Service;
using Xunit;

namespace UnitTests
{
    public class BlockingTests
    {
        private static IExaminationPreviousRepository CreatePreviousRepository()
        {
            var stubRepositoryPrevious = new Mock<IExaminationPreviousRepository>();
            List<Examination> previous = new List<Examination>();
            previous.Add(new Examination(3, new Patient(2, "Andjela", "Petrovic"), false, DateTime.Parse("08/15/2020 07:22:16")));
            stubRepositoryPrevious.Setup(m => m.GetAllEager()).Returns(previous);

            return stubRepositoryPrevious.Object;
        }

        private static IExaminationUpcomingRepository CreateUpcomingRepository()
        {
            var stubRepositoryUpcoming = new Mock<IExaminationUpcomingRepository>();
            List<Examination> upcoming = new List<Examination>();
            upcoming.Add(new Examination(1, new Patient(1, "Marjana", "Zalar"), true, DateTime.Parse("08/18/2020 07:22:16")));
            upcoming.Add(new Examination(2, new Patient(1, "Marjana", "Zalar"), true, DateTime.Parse("08/15/2020 07:22:16")));
            upcoming.Add(new Examination(4, new Patient(1, "Marjana", "Zalar"), true, DateTime.Parse("08/16/2020 07:22:16")));
            stubRepositoryUpcoming.Setup(m => m.GetAllEager()).Returns(upcoming);

            return stubRepositoryUpcoming.Object;
        }

        private static List<DateTime> CreateDateTimeList()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse("08/18/2020 07:22:16"));
            dates.Add(DateTime.Parse("08/15/2020 07:22:16"));
            dates.Add(DateTime.Parse("10/18/2020 07:22:16"));
            return dates;
        }

        private static IPatientRepository CreatePatientRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient(1, "Marjana", "Zalar"));
            patients.Add(new Patient(2, "Andjela", "Petrovic"));
            stubRepository.Setup(m => m.GetEager()).Returns(patients);
            return stubRepository.Object;
        }

       [Fact]
        public void CheckIfBlockedTrue()
        {
            List<DateTime> dates = CreateDateTimeList();
            dates.Add(DateTime.Parse("08/11/2020 07:22:16"));
            PatientService service = new PatientService(CreatePatientRepository());
            bool result = service.CheckIfBlocked(dates);
            Assert.True(result);
        }

        [Fact]
        public void CheckIfBlockedFalse()
        {
            List<DateTime> dates = CreateDateTimeList();
            dates.Add(DateTime.Parse("11/11/2020 07:22:16"));
            PatientService service = new PatientService(CreatePatientRepository());
            bool result = service.CheckIfBlocked(dates);
            Assert.False(result);
        }

        [Fact]
        public void GetCancelationDatesNotEmpty()
        {
            ExaminationService service = new ExaminationService(CreateUpcomingRepository(), CreatePreviousRepository());
            List<DateTime> result = service.GetCancelationDatesByPatient(1);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetCancelationDatesEmpty()
        {
           
            ExaminationService service = new ExaminationService(CreateUpcomingRepository(), CreatePreviousRepository());
            List<DateTime> result = service.GetCancelationDatesByPatient(2);
            Assert.Empty(result);
        }

        [Fact]
        public void GetPatientsForBlocking()
        {
            ExaminationService examination_service = new ExaminationService(CreateUpcomingRepository(), CreatePreviousRepository());
            PatientService service = new PatientService(CreatePatientRepository(), null, null, examination_service);
            List<Patient> result = service.GetPatientsForBlocking();
            Assert.NotEmpty(result);
        }

    }
}
