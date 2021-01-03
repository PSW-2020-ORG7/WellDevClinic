using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Examination : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public Boolean Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public Examination() { }
        public Examination(long id, Patient patient, Doctor doctor, Period period, bool canceled, DateTime canceledDate)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Canceled = canceled;
            CanceledDate = canceledDate;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }

}
   
