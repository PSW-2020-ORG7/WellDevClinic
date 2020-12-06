using System;
using System.Collections.Generic;
using System.Text;
using Model.Users;
using WellDevCore.Model.dtos;

namespace WellDevCore.Model.Adapters
{
    class PatientAdapter
    {

        public static PatientDTO DoctorGradeToDoctorGradeDTO(Patient patient)
        {
            PatientDTO result = new PatientDTO();
            result.Id = patient.Id;
            result.FullName = patient.FullName;
            result.Username = patient.Username;
            return result;
        }
    }
}
