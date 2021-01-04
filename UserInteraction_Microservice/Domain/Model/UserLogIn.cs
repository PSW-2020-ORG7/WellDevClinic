using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
   
    public class UserLogIn : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
       
        public UserLogIn() {}

        public UserLogIn(long id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
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
