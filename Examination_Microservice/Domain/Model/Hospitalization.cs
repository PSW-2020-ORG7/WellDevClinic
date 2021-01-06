using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
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
