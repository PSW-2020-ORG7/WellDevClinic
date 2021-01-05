using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Operation : IIdentifiable<long>
    {
        public virtual Doctor Doctor { get; set; }
        public String Description { get; set; }
        public virtual Period Period { get; set; }
        public virtual Room Room { get; set; }
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }

        public Operation(Doctor doctor, string description, Period period, Room room, long id, Patient patient)
        {
            Doctor = doctor;
            Description = description;
            Period = period;
            Room = room;
            Id = id;
            Patient = patient;
        }

        public Operation()
        {
        }

        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
