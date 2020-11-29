using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Model.Dto
{
   public class BusinessDayDTO
    {
        public long Id { get; set; }
        public virtual Doctor Doctor { get; set; }
      public virtual Period Period { get; set; }
      public  Boolean PatientScheduling = false;
    public BusinessDayDTO(Doctor doctor, Period period)
        {
            this.Doctor = doctor;
            this.Period = period;
        }

        public BusinessDayDTO()
        {
            
        }

    }
}
