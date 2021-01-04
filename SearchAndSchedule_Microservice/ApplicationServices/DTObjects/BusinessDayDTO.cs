using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.DTObjects
{
    public enum PriorityType
    {
        NoPriority,
        Doctor,
        Date,

    }
    public class BusinessDayDTO
    {
        public  Doctor Doctor { get; set; }
        public  Period Period { get; set; }
        public Boolean PatientScheduling = false;
        public PriorityType Priority { get; set; }
        public BusinessDayDTO(Doctor doctor, Period period)
        {
            this.Doctor = doctor;
            this.Period = period;
        }

        public BusinessDayDTO(Doctor doctor, Period period, PriorityType priority)
        {
            this.Doctor = doctor;
            this.Period = period;
            this.Priority = priority;
        }

        public BusinessDayDTO()
        {

        }

    }
}
