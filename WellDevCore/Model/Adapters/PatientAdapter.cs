using System;
using System.Collections.Generic;
using System.Text;
using Model.Users;
using WellDevCore.Model.dtos;

namespace WellDevCore.Model.Adapters
{
    public class PatientAdapter
    {

        public static PatientDTO PatientToPatientDTO(Patient patient)
        {
            PatientDTO result = new PatientDTO();
            result.Id = patient.Id;
            result.FullName = patient.FullName;
            result.Username = patient.Username;
            result.Blocked = patient.Blocked;
            return result;
        }
    }
}
