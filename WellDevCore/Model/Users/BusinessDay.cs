

using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class BusinessDay : IIdentifiable<long>
    {
      public virtual Period Shift { get; set; }

        public long Id { get; set; }
        public virtual List<Period> ScheduledPeriods { get; set; }
      public virtual Doctor doctor { get; set; }
      public virtual Room room { get; set; }

        public BusinessDay(Period shift, Doctor doctor, Room room, List<Period> periods)
        {
            this.Shift = shift;
            this.ScheduledPeriods = periods;
            this.doctor = doctor;
            this.room = room;
        }
        public BusinessDay(long id,Period shift,  Doctor doctor, Room room, List<Period> periods)
        {
            this.Id = id;
            this.Shift = shift;
            this.ScheduledPeriods = periods;
            this.doctor = doctor;
            this.room = room;
        }
        public BusinessDay (long id)
        {
            this.Id = id;
        }
        public BusinessDay()
        {
            
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}