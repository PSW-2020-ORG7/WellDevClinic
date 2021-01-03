using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class Patient : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false;
        public Boolean Blocked { get; set; } = false;
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
