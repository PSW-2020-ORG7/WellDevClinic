using System;
using Xunit;
using Model.Doctor;
using PSW_Web_app.Controllers;
using Xunit;
using System.Collections.Generic;

namespace PSW_Web_app_Tests
{
    public class SurveyTests
    {
        [Fact]
        public void Creating_survey()
        {
            SurveyController controller = new SurveyController();
            DoctorGrade survey = new DoctorGrade();
            DoctorGrade result = controller.SaveSurvey(survey);
            Assert.NotNull(result);
        }

        [Fact]
        public void Getting_all_surveys()
        {
            SurveyController controller = new SurveyController();
            List<DoctorGrade> result = controller.GetAll();
            Assert.NotEmpty(result);
        }
    }
}
