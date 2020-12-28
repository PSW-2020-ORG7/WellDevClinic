﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class UserDetails : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Phone { get; set; }
        public String MiddleName { get; set; }
        public String Race { get; set; }
        public String Gender { get; set; }
        public String Email { get; set; }
        public String Image { get; set; }
        public virtual Address Address { get; set; }

        public UserDetails(long id, DateTime dateOfBirth, string phone, string middleName, string race, string gender, string email, string image, Address address)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            MiddleName = middleName;
            Race = race;
            Gender = gender;
            Email = email;
            Image = image;
            Address = address;
        }

        public UserDetails()
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
