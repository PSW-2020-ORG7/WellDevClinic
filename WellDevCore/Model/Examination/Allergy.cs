
using System;

namespace Model.PatientSecretary
{
   public class Allergy
   {
      public String Name { get; set; }
        public long Id { get; set; }

        public Allergy(String name)
        {
            Name = name;
        }

        public Allergy()
        {
            
        }
    }
}