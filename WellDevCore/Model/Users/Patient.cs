

using Model.PatientSecretary;
using System;


namespace Model.Users
{
   public class Patient : User
    {
      public PatientFile patientFile { get; set; }
      public Boolean Guest = false;
      public String MiddleName { get; set; }
      public Boolean Validation { get; set; }
      public String Gender { get; set; }
      public String Race { get; set; }
      public String BloodType { get; set; }

      public String VerificationToken { get; set; }

        public Patient() { }
        public Patient(long id,String name, String middleName, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, String gender, String race, String bloodtype, Boolean validation, String verificationToken)
        {
            this.Id = id;
            this.FirstName = name;
            this.MiddleName = middleName;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            //this.Image = img;
            this.Gender = gender;
            this.Race = race;
            this.BloodType = bloodtype;
            this.Validation = validation;
            this.VerificationToken = verificationToken;

        }
        public Patient(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, /*Uri img,*/ PatientFile patientFile, Boolean guest)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            //this.Image = img;
            this.patientFile = patientFile;
            this.Guest = guest;
        }

        public Patient(String name, String surname, String jmbg, String email, String phone, DateTime birth, Boolean guest)
        {
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Guest = guest;
        }

        public Patient(long id)
        {
            this.Id = id;
        }

        public Patient(Boolean guest)
        {
            Guest = guest;
        }
        override
        public long GetId()
        {
            return this.Id;
        }

        override
        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}