using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSW_Web_app.Models
{
    public class Secretary : User, IIdentifiable<long>
    {
        public long Id { get; set; }

        public Secretary()
        {
            UserType = UserType.Secretary;
        }

        public Secretary(long id, Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Id = id;
            UserType = UserType.Secretary;
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;
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
