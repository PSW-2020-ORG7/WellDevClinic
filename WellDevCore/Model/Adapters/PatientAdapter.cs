using bolnica.Model.dtos;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using WellDevCore.Model.dtos;

namespace WellDevCore.Model.Adapters
{
    public class PatientAdapter
    {
        public static PatientDto PatientToPatientDto(Patient patient)
        {
            PatientDto dto = new PatientDto();
            dto.Username = patient.Username;
            dto.FullName = patient.FullName;
            dto.MiddleName = patient.MiddleName;
            dto.Date = patient.DateOfBirth.ToString("MMMM dd, yyyy") + ".";
            dto.Address = patient.Address.GetFullAddress();
            dto.Phone = patient.Phone;
            dto.Email = patient.Email;
            dto.Gender = patient.Gender;
            dto.BloodType = patient.BloodType;
            dto.Image = patient.Image;
            List<String> allergies = new List<String>();
            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                allergies.Add(allergy.Name);
            }
            dto.Allergies = allergies;
            List<ExaminationDto> examinations = new List<ExaminationDto>();


            return dto;
        }
    }
}
