using System;
using Xunit;
using Model.Doctor;
using System.Collections.Generic;
using Moq;
using Repository;
using Service;
using bolnica.Model.Dto;
using Shouldly;


namespace UnitTests
{
    public class SurveyTests
    {
        [Fact]
        public void Creating_survey()
        {
            var stubRepository = new Mock<IDoctorGradeRepository>();
            var surveys = new List<DoctorGrade>();
            GradeDTO grade = new GradeDTO(5, "doctor1");
            List<GradeDTO> grades = new List<GradeDTO>();
            grades.Add(grade);
            DoctorGrade survey = new DoctorGrade(grades, "Marjana Zalar");
            surveys.Add(survey);
            stubRepository.Setup(m => m.Save(survey)).Returns(survey);

            DoctorGradeService service = new DoctorGradeService(stubRepository.Object);
            DoctorGrade result = service.Save(survey);
            Assert.NotNull(result);
        }

        [Fact]
        public void Getting_all_surveys()
        {
            var stubRepository = new Mock<IDoctorGradeRepository>();
            var surveys = new List<DoctorGrade>();
            GradeDTO grade = new GradeDTO(5, "doctor1");
            List<GradeDTO> grades = new List<GradeDTO>();
            grades.Add(grade);
            DoctorGrade survey = new DoctorGrade(grades, "Marjana Zalar");
            surveys.Add(survey);
            stubRepository.Setup(m => m.GetEager()).Returns(surveys);

            DoctorGradeService service = new DoctorGradeService(stubRepository.Object);
            List<DoctorGrade> result = (List<DoctorGrade>)service.GetAll();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Getting_surveys_by_doctor_passing()
        {
            var stubRepository = new Mock<IDoctorGradeRepository>();
            var surveys = new List<DoctorGrade>();
            GradeDTO grade = new GradeDTO(5, "doctor1");
            List<GradeDTO> grades = new List<GradeDTO>();
            grades.Add(grade);
            DoctorGrade survey = new DoctorGrade(grades, "Marjana Zalar");
            DoctorGrade survey1 = new DoctorGrade(grades, "Petar Petrovic");
            surveys.Add(survey);
            surveys.Add(survey1);
            stubRepository.Setup(m => m.GetEager()).Returns(surveys);

            DoctorGradeService service = new DoctorGradeService(stubRepository.Object);
            List<DoctorGrade> result = service.GetByDoctor("Marjana Zalar");
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Getting_surveys_by_doctor_failed()
        {
            var stubRepository = new Mock<IDoctorGradeRepository>();
            var surveys = new List<DoctorGrade>();
            GradeDTO grade = new GradeDTO(5, "doctor1");
            List<GradeDTO> grades = new List<GradeDTO>();
            grades.Add(grade);
            DoctorGrade survey = new DoctorGrade(grades, "Marjana Zalar");
            DoctorGrade survey1 = new DoctorGrade(grades, "Petar Petrovic");
            surveys.Add(survey);
            surveys.Add(survey1);
            stubRepository.Setup(m => m.GetEager()).Returns(surveys);

            DoctorGradeService service = new DoctorGradeService(stubRepository.Object);
            List<DoctorGrade> result = service.GetByDoctor("Andjela Petrovic");
            result.ShouldBeEmpty();
        }
    }
}
