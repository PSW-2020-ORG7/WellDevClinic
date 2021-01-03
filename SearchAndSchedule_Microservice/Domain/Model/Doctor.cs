using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Doctor :  IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }

        public Doctor(){ }

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
