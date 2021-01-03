using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class BussinesDay : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Period Shift { get; set; }
        public virtual List<Period> ScheduledPeriods { get; set; }
        public virtual Doctor doctor { get; set; }
        public virtual Room room { get; set; }

        public BussinesDay() { }
        public BussinesDay(long id, Period shift, List<Period> scheduledPeriods, Doctor doctor, Room room)
        {
            Id = id;
            Shift = shift;
            ScheduledPeriods = scheduledPeriods;
            this.doctor = doctor;
            this.room = room;
        }

        public BussinesDay(Period shift, Doctor doctor, Room room, List<Period> scheduledPeriods)
        {
            Shift = shift;
            ScheduledPeriods = scheduledPeriods;
            this.doctor = doctor;
            this.room = room;
        }
        public BussinesDay(long id)
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
