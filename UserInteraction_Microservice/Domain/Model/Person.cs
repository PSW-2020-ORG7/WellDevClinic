using System;
using System.Collections.Generic;
using System.Text;

namespace UserInteraction_Microservice.Domain.Model
{
    public class Person : IIdentifiable<long>
    {
        public long Id { get; set; }
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

        public Person() { }

        public Person(long id, String FirstName, String LastName, String Jmbg)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Jmbg = Jmbg;
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
