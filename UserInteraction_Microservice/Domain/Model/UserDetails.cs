using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class UserDetails : Person
    {
        public DateTime DateOfBirth { get; set; }
        public String Phone { get; set; }
        public String MiddleName { get; set; }
        public String Race { get; set; }
        public String Gender { get; set; }
        public String Email { get; set; }
        public String Image { get; set; }
        public virtual Address Address { get; set; }

        public UserDetails()
        {
        }

        public UserDetails(String jmbg, String firstName, String lastName,DateTime dateOfBirth, string phone, string middleName, string race, string gender, string email, string image, Address address)
        {
            Jmbg = jmbg;
            FirstName = firstName;
            LastName = LastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            MiddleName = middleName;
            Race = race;
            Gender = gender;
            Email = email;
            Image = image;
            Address = address;
        }
    }

}
