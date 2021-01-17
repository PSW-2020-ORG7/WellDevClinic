using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Models.Examination;

namespace PSW_Web_app.Models
{
    public class Hospitalization : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual Room Room { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

        public Hospitalization() { }

        public Hospitalization(long id, Period period, Room room, Doctor doctor, Patient patient)
        {
            Id = id;
            Period = period;
            Room = room;
            Doctor = doctor;
            Patient = patient;
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
