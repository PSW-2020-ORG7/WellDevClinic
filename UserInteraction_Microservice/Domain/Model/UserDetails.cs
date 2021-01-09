using System;
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
        public String BloodType { get; set; }
        public virtual Address Address { get; set; }

        public UserDetails() { }

        public UserDetails(long id, DateTime dateOfBirth, string phone, string middleName, string race, string gender,string bloodtype, string email, string image, Address address)
        {
            if (string.IsNullOrWhiteSpace(phone) || dateOfBirth == null || string.IsNullOrWhiteSpace(middleName) || string.IsNullOrWhiteSpace(race)
                || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(image) || address == null)
                throw new ArgumentNullException();

            Id = id;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            MiddleName = middleName;
            Race = race;
            Gender = gender;
            BloodType = bloodtype;
            Email = email;
            Image = image;
            Address = address;
        }

        public void UpdateDateOfBirth(DateTime newDateOfBirth)
        {
            ValidateDateOfBirth(newDateOfBirth);
            DateOfBirth = newDateOfBirth;

        }
        public void UpdatePhone(string newPhone)
        {
            ValidateString(newPhone);
            Phone = newPhone;
        }
        public void UpdateMiddleName(string newMiddleName)
        {
            ValidateString(newMiddleName);
            MiddleName = newMiddleName;

        }
        public void UpdateRace(string newRace)
        {
            ValidateString(newRace);
            Race = newRace;
        }
        public void UpdateGender(string newGender)
        {
            ValidateString(newGender);
            Gender = newGender;

        }
        public void UpdateEmail(string newEmail)
        {
            ValidateString(newEmail);
            Email = newEmail;
        }
        public void UpdateImage(string newImage)
        {
            ValidateString(newImage);
            Image = newImage;
        }
        public void UpdateAddress(Address newAddress)
        {
            ValidateAddress(newAddress);
            Address = newAddress;
        }

        private void ValidateDateOfBirth(DateTime date)
        {
            if (date == null)
                throw new ArgumentNullException();

        }
        private void ValidateString(string validationObject)
        {
            if (string.IsNullOrWhiteSpace(validationObject))
                throw new ArgumentNullException();

        }

        private void ValidateAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException();

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
