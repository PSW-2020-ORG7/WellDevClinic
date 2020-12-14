using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.dtos
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        public List<BusinessDayDTO> BusinessDayDTOs { get; set; } = new List<BusinessDayDTO>();
        public String Speciality { get; set; }

        public DoctorDTO() {}
    }

}
