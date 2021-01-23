using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.DTObjects
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
