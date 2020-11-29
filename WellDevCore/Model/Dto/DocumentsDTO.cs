using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.Dto
{
    public class DocumentsDTO
    {
        public long Id { get; set; }
        public String Date { get; set; }
        public String Doctor { get; set; }
        public String Type { get; set; }
        public String Drug { get; set; }
        public String Specialist { get; set; }

        public Patient User { get; set; }
        public DocumentsDTO()
        {
        }

        public DocumentsDTO(String date, String doctorName, String drugName, String specialistName, String type, Patient user)
        {
            Date = date;
            Doctor = doctorName;
            Drug = drugName;
            Specialist = specialistName;
            Type = type;
            User = user;
        }
    }
}
