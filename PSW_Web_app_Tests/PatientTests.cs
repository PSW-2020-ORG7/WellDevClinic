
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Controllers;
using Xunit;

namespace PSW_Web_app_Tests
{
    class PatientTests
    {
        public void Getting_patient()
        {
            PatientController patientController = new PatientController();
            Patient result = patientController.GetPatientById(1);

            Assert.NotNull(result);
        }
    }
}
