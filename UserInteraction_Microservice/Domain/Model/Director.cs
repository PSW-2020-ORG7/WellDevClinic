using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Director : User, IIdentifiable<long>
    {
        public long Id { get; set; }

        public Director(long id, Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Id = id;
            UserType = UserType.Director;
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;
        }

        public Director()
        {
            UserType = UserType.Director;
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
