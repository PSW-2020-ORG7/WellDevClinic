using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model.DTO
{
    public class ExactDayDTO
    {
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public ExactDayDTO(Doctor doctor, DateTime date)
        {
            this.Doctor = doctor;
            this.Date = date;
        }

        public ExactDayDTO()
        {

        }
    }
}
