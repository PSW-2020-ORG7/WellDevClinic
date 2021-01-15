using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Models.Examination;

namespace PSW_Web_app.Models
{
    public class Operation : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Period Period { get; set; }
        public virtual Room Room { get; set; }
        public String Description { get; set; }

        public Operation() { }

        public Operation(long id, Patient patient, Doctor doctor, Period period, Room room, string description)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Room = room;
            Description = description;
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
