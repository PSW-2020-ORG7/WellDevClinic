using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.Dto
{
    public class DocumentsDTO2
    {
        public long Id { get; set; }
        public String Date { get; set; }
        public String Date2 { get; set; }
        public String Doctor { get; set; }
        public String Type { get; set; }
        public String Drug { get; set; }
        public String Specialist { get; set; }
        public String Text { get; set; }

        public Patient User { get; set; }

        public Boolean Radio1 { get; set; }
        public Boolean Radio2 { get; set; }
        public Boolean Radio3 { get; set; }
        public Boolean Radio4 { get; set; }
        
        public DocumentsDTO2()
        {
        }

        public DocumentsDTO2(String date, String date2, String doctorName, String drugName, String specialistName, String text, String type, Patient user, Boolean radio1, Boolean radio2, Boolean radio3, Boolean radio4)
        {
            Date = date;
            Date2 = date2;
            Doctor = doctorName;
            Drug = drugName;
            Specialist = specialistName;
            Text = text;
            Type = type;
            User = user;
            Radio1 = radio1;
            Radio2 = radio2;
            Radio3 = radio3;
            Radio4 = radio4;
        }
    }
}
