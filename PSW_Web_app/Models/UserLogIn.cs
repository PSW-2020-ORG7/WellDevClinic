using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
{
   
    public class UserLogIn : IIdentifiable<long>
    {
        public long Id { get;  set; }
        public String Username { get;  set; }
        public String Password { get;  set; }
       
        public UserLogIn() {}

        public UserLogIn(long id, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException();
            Id = id;
            Username = username;
            Password = password;
        }

        public void UpdateUsername(string newUsername)
        {
            ValidateUsername(newUsername);
            Username = newUsername;

        }
        public void UpdatePassword(string newPassword)
        {
            ValidatePassword(newPassword);
            Password = newPassword;
        }

        private void ValidateUsername(string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
                throw new ArgumentNullException();

        }

        private void ValidatePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
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
