using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Doctor : User
    {
        public Speciality Speciality { get; set; }
        public DoctorGrade DoctorGrade { get; set; }

        public Doctor(long id, String jmbg, String firstName, String lastName, DateTime dateOfBirth, string phone, string middleName, string race, string gender, string email, string image, Address address, string username, string password, UserType userType, Speciality speciality, DoctorGrade doctorGrade)
        {
            Id = id;
            Username = username;
            Password = password;
            UserType = userType;
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
            Speciality = speciality;
            DoctorGrade = doctorGrade;
        }

    }
}
