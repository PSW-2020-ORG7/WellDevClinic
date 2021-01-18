using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    
    public class BusinessDayDTO
    {
        public long Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }

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
        }

        public BusinessDayDTO()
        {

        }
    }
}
