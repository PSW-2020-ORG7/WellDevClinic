using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }

        public User() { }
        public User(string username, string password) 
        {
            this.username = username;
            this.password = password;
        }

    }
}
