using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class UpcomingExamination
    {

        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public Boolean Canceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public UpcomingExamination() { }

        public UpcomingExamination(Doctor doctor, Period period, Patient patient) 
        {
            Doctor = doctor;
            Period = period;
            Patient = patient;
        }
    }
}
