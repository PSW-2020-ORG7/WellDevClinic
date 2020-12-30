﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Patient : User, IIdentifiable<long>
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false; 
        public Boolean Blocked { get; set; } = false;
        public Patient()
        {
            UserType = UserType.Patient;
        }

        public Patient(long id, bool guest, bool blocked, Person person, UserDetails userDetails, UserLogIn userLogIn)
        {
            Id = id;
            Guest = guest;
            Blocked = blocked;
            UserType = UserType.Patient;
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