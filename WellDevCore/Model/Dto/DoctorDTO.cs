using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.Dto
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public String FullName { get; set; }

        public DoctorDTO(long id, String fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
