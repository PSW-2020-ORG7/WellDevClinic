using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;
using WellDevCore.Model.dtos;

namespace WellDevCore.Model.Adapters
{
    public class DoctorAdapter
    {
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.Id = doctor.Id;
            doctorDTO.Name = doctor.FirstName;
            doctorDTO.Surname = doctor.LastName;
            doctorDTO.Speciality = doctor.Specialty.Name;
            List<BusinessDayDTO> businessDayDTOs = new List<BusinessDayDTO>();
            return doctorDTO;

        }

        public static DoctorDTO DoctorToDoctorDTO2(Doctor doctor){
            //DoctorDTO dto = new DoctorDTO(doctor.Id, doctor.FullName);
            DoctorDTO dto = new DoctorDTO();
            return dto;
        }
    }
}
