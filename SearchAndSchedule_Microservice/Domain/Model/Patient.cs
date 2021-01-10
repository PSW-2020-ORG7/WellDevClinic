using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Patient : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false;
        public Boolean Blocked { get; set; } = false;
        public virtual Person Person { get; set; }

        public Patient(long id, bool guest, bool blocked, Person person)
        {
            Id = id;
            Guest = guest;
            Blocked = blocked;
            Person = person;
        }

        public Patient()  { }

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
