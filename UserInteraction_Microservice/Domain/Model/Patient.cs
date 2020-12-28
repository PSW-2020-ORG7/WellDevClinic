using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Patient : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false; 
        public Boolean Blocked { get; set; } = false;
        public virtual User User { get; set; }

        public Patient(long id, bool guest, bool blocked, User user)
        {
            Id = id;
            Guest = guest;
            Blocked = blocked;
            User = user;
        }

        public Patient()
        {
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
