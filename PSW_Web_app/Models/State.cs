using System;
using System.Collections.Generic;

namespace PSW_Web_app.Models
{
    public class State
    {
        public String Name { get; private set; }
        public String Code { get; private set; }

        public State() {}

        public State(String name, String code)
        {
            Validate(name, code);
            Name = name;
            Code = code;
        }
        private void Validate(String name, String code)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException();
        }


    }
}