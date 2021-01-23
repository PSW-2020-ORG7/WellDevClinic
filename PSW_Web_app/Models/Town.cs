using System;
using System.Collections.Generic;

namespace PSW_Web_app.Models
{ 
    public class Town
    {
        public String Name { get; private set; }
        public String PostalNumber { get; private set; }

        public Town() {}

        public Town(string name, string postalNumber, State state)
        {
            Validate(name, postalNumber, state);
            Name = name;
            PostalNumber = postalNumber;
        }
        private void Validate(string name, string postalNumber, State state)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(postalNumber))
                throw new ArgumentNullException();

            if (state == null)
                throw new ArgumentException("You must enter state!");
        }

    }
}