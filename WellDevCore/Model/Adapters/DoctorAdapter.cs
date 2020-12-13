using System;
using System.Collections.Generic;
using System.Text;
using Model.Users;
using WellDevCore.Model.Dto;

namespace WellDevCore.Model.Adapters
{
    public class DoctorAdapter
    {
        public static DoctorDTO DoctorToDoctorDTO(Doctor doctor)
        {
            DoctorDTO dto = new DoctorDTO(doctor.Id, doctor.FullName);
            return dto;
        }
    }
}
