using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PSW_Web_app.Models.UserInteraction
{
    public class Patient : User, IIdentifiable<long>
    {
        public long Id { get; set; }
        public Boolean Guest { get; set; } = false; 
        public Boolean Blocked { get; set; } = false;
        public Boolean Validation { get; set; }
        public String VerificationToken { get; set; }
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
            Validation = false;

        }

        public Patient(long id, bool guest, bool blocked, Person person, UserDetails userDetails, UserLogIn userLogIn, string verificationToken)
        {
            Id = id;
            Guest = guest;
            Blocked = blocked;
            UserType = UserType.Patient;
            Person = person;
            UserDetails = userDetails;
            UserLogIn = userLogIn;
            Validation = false;
            VerificationToken = verificationToken;

        }

        public void ClaimAccount()
        {
            if (!(!this.UserDetails.Phone.Equals("") && !this.UserDetails.Email.Equals("")))
                throw new ApplicationException();
            this.Guest = false;
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
