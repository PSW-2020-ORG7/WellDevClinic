using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
  
    public class User
    { 
        public long Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public virtual UserLogIn UserLogIn { get; set; }

        public User(Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;
        }

        public User()
        {
        }
    }
}
