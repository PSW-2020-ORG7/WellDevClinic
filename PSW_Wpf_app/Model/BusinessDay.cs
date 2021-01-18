using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public enum PriorityType
    {
        NoPriority,
        Doctor,
        Date,

    }
    public class BusinessDay
    {
        public long Id { get; set; }
        public virtual Period Shift { get; set; }
        public virtual List<Period> ScheduledPeriods { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Room Room { get; set; }

        public PriorityType Priority { get; set; }
        public BusinessDay() { }
    }
}
