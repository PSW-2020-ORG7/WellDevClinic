using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public enum UserType
    {
        Patient,
        Doctor,
        Secretary,
        Director
    }
    public class User : UserDetails, IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public virtual UserType UserType { get; set; }

        public User(long id, String jmbg, String firstName, String lastName, DateTime dateOfBirth, string phone, string middleName, string race, string gender, string email, string image, Address address, string username, string password, UserType userType)
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

        public User() { }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}
