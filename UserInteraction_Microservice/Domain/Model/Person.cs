using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Person 
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Jmbg  { get; set; }

        public String FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

        public Person( String FirstName, String LastName, String Jmbg)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Jmbg = Jmbg;
        }

        public Person() { }

    }
}
