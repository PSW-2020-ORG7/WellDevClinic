using System;
using System.Collections.Generic;
using System.Text;
using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using Moq;
using Repository;
using Service;
using Xunit;

namespace ServiceTests
{
    public class AppointmentRecommendation
    {
        private static IDoctorRepository CreateDoctorRepository1()
        {
            var stubRepositoryDoctor = new Mock<IDoctorRepository>();
            List<Doctor> previous = new List<Doctor>();
            previous.Add(new Doctor(2, "doc", "doc"));
            stubRepositoryDoctor.Setup(m => m.GetAllEager()).Returns(previous);

            return stubRepositoryDoctor.Object;
        }

        private static List<DateTime> CreateDateTimeList()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse("08/18/2020 07:22:16"));
            dates.Add(DateTime.Parse("08/15/2020 07:22:16"));
            dates.Add(DateTime.Parse("10/18/2020 07:22:16"));
            return dates;
        }

        private static List<DateTime> CreateDateTimeList2()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Parse("08/18/2020 07:22:16"));
            dates.Add(DateTime.Parse("08/15/2020 07:22:16"));
            dates.Add(DateTime.Parse("10/18/2020 07:22:16"));
            return dates;
        }

        private static IDoctorRepository CreateDoctorRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor(1, "doktor", "doktor"));
            doctors.Add(new Doctor(2, "ime", "prezime"));
            stubRepository.Setup(m => m.GetAllEager()).Returns(doctors);
            return stubRepository.Object;
        }

        private static IExaminationUpcomingRepository CreateExamRepository()
        {
            var stubRepository = new Mock<IExaminationUpcomingRepository>();
            List<Examination> exams = new List<Examination>();
            exams.Add(new Examination(1, new Doctor(1, "lekar", "lek"), new Period()));
            exams.Add(new Examination(1, new Doctor(1, "doktor", "doc"), new Period()));
            exams.Add(new Examination(1, new Doctor(1, "asd", "dsa"), new Period()));
            stubRepository.Setup(m => m.GetAllEager()).Returns(exams);
            return stubRepository.Object;
        }

        private static IBusinessDayRepository CreateBusinessDayRepository()
        {
            var stubRepository = new Mock<IBusinessDayRepository>();
            List<BusinessDay> bds = new List<BusinessDay>();
            bds.Add(new BusinessDay(null, new Doctor(1, "lekar", "lek"), new Model.Director.Room(), null));
            stubRepository.Setup(m => m.GetAllEager()).Returns(bds);
            return stubRepository.Object;
        }

        [Fact]
        public void GetDoctors()
        {
            DoctorService service = new DoctorService(CreateDoctorRepository());
            List<Doctor> result = (List<Doctor>)service.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetExams()
        {
            ExaminationService service = new ExaminationService(CreateExamRepository(),null);
            List<Examination> result = (List<Examination>)service.GetAll();
            Assert.NotEmpty(result);

        }

        [Fact]
        public void getBusinessDays()
        {
            BusinessDayService service = new BusinessDayService((IBusinessDayRepository)CreateBusinessDayRepository(), new DoctorService(CreateDoctorRepository()));
            List<BusinessDay> result = (List<BusinessDay>)service.GetAll();
            Assert.NotEmpty(result);
        }

    }
}
