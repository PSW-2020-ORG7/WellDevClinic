﻿using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Model.Dto
{
    public enum PriorityType
    {
        NoPriority,
        Doctor,
        Date,

    }
    public class BusinessDayDTO
    {
        public long Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public  Boolean PatientScheduling = false;
        public PriorityType Priority { get; set; }
        public long RoomId { get; set; }

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
