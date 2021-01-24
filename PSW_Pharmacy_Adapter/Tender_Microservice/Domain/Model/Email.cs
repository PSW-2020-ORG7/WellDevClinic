using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class Email
    {
        public string Mail { get; private set; }

        public Email(string mail)
        {
            Mail = mail;
            Validate();
        }

        private void Validate()
        {
            Regex regex = new Regex(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$");
            if (!regex.Match(Mail).Success)
                throw new ArgumentException("Invalid argument", nameof(Mail));
        }

    }
}
