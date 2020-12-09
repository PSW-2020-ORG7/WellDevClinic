using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.dtos
{
    public class PatientDTO
    {
        public long Id { get; set; }
        public String FullName { get; set; }
        public String Username { get; set; }
        public bool Blocked { get; set; }


       
        public String MiddleName { get; set; }
        public String Image { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String BloodType { get; set; }
        public String Date { get; set; }
        public List<String> Allergies { get; set; }


        public PatientDTO() { }

        public PatientDTO(long id, string fullName, string username, bool blocked)
        {
            Id = id;
            FullName = fullName;
            Username = username;
            Blocked = blocked;
        }
    }
}
