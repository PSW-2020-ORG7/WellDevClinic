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
