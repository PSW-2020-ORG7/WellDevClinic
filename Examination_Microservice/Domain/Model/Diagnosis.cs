using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Diagnosis : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Diagnosis() { }

        public Diagnosis(long id, string name)
        {
            Id = id;
            Name = name;
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
