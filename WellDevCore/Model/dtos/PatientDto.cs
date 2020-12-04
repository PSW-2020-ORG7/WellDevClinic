using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.dtos
{
 
    public class PatientDto
    {
        public String Username { get; set; }
        public String FullName { get; set; }
        public String MiddleName { get; set; }
        public String Image { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String BloodType { get; set; }
        public String Date { get; set; }
        public List<String> Allergies { get; set; }


        public PatientDto() { }
    }
}
