using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class Hospitalization : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual Room Room { get; set; }
        public virtual Model.Users.Doctor Doctor { get; set; }
        public virtual User Patient { get; set; }

        public Hospitalization(long id, User patient, Model.Users.Doctor doctor, Period period, Room room)
        {
            Patient = patient;
            Doctor = doctor;
            Id = id;
            Period = period;
            Room = room;
        }
        public Hospitalization(User patient, Model.Users.Doctor doctor, Period period, Room room)
        {
            Patient = patient;
            Doctor = doctor;
            Period = period;
            Room = room;
        }


        public Hospitalization(Period period, Room room)
        {
            Period = period;
            Room = room;
        }

        public Hospitalization() { }

       public Hospitalization(long id)
        {
            Id = id;
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