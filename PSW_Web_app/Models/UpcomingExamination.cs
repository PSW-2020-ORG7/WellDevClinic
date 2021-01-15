using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Models.SearchAndSchedule;

namespace PSW_Web_app.Models
{
    public class UpcomingExamination : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public Boolean Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public UpcomingExamination() { }
        public UpcomingExamination(long id, Patient patient, Doctor doctor, Period period, bool canceled, DateTime canceledDate)
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
   
