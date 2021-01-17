using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Web_app.Models
{
    public class Allergy : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        
        public Allergy() { }
        public Allergy(long id, string name)
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
