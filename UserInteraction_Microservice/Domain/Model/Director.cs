using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Director : User
    {
        public Director(long id, String jmbg, String firstName, String lastName, DateTime dateOfBirth, string phone, string middleName, string race, string gender, string email, string image, Address address, string username, string password, UserType userType)
        {
            Id = id;
            UserType = userType;
            Username = username;
            Password = password;
            Jmbg = jmbg;
            FirstName = firstName;
            LastName = lastName;
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
