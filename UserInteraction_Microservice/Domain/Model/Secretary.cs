using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Secretary : IIdentifiable<long>
    {
        public long Id { get; set; }

        public virtual User User { get; set; }

        public Secretary(long id, User user)
        {
            Id = id;
            User = user;
        }

        public Secretary()
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
