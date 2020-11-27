using System;
using Xunit;
using Model.Doctor;
using PSW_Web_app.Controllers;
using Xunit;
using System.Collections.Generic;
using Moq;
using Repository;
using Service;
using bolnica.Model.Dto;

namespace PSW_Web_app_Tests
{
    public class SurveyTests
    {
        [Fact]
        public void Creating_survey()
        {
            SurveyController controller = new SurveyController();
            GradeDTO grade = new GradeDTO(5,"doctor1");
            List<GradeDTO> grades = new List<GradeDTO>();
            grades.Add(grade);
            DoctorGrade survey = new DoctorGrade(grades);
            DoctorGrade result = controller.SaveSurvey(survey);
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
            DoctorGrade survey = new DoctorGrade(grades);
            surveys.Add(survey);
            stubRepository.Setup(m => m.GetAll()).Returns(surveys);

            DoctorGradeService service = new DoctorGradeService(stubRepository.Object);
            List<DoctorGrade> result = (List<DoctorGrade>)service.GetAll();
            Assert.NotEmpty(result);
        }
    }
}
