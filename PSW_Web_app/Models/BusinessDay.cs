using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Models.SearchAndSchedule;

namespace PSW_Web_app.Models
{
    public class BusinessDay : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Period Shift { get; set; }
        public virtual List<Period> ScheduledPeriods { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Room Room { get; set; }

        public BusinessDay() { }
        public BusinessDay(long id, Period shift, List<Period> scheduledPeriods, Doctor doctor, Room room)
        {
            Id = id;
            Shift = shift;
            ScheduledPeriods = scheduledPeriods;
            this.Doctor = doctor;
            this.Room = room;
        }

        public BusinessDay(Period shift, Doctor doctor, Room room, List<Period> scheduledPeriods)
        {
            Shift = shift;
            ScheduledPeriods = scheduledPeriods;
            this.Doctor = doctor;
            this.Room = room;
        }
        public BusinessDay(long id)
        {
            Id = id;
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
