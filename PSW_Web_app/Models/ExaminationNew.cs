using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Web_app.Models.UserInteraction;

namespace PSW_Web_app.Models
{
    public class ExaminationNew : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public Boolean Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public ExaminationNew() { }
        public ExaminationNew(long id, Patient patient, Doctor doctor, Period period, bool canceled, DateTime canceledDate)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Canceled = canceled;
            CanceledDate = canceledDate;
        }

        public ExaminationNew(long id, Patient patient, Doctor doctor, Period period)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Canceled = false;
        }

        public ExaminationNew(Patient patient, Doctor doctor, Period period)
        {
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Canceled = false;
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
