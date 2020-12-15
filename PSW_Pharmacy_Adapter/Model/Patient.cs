using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Patient
    {

        public long Jmgb { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Allergy> Allergies { get; set; }


        public Patient() { }
        public Patient(long jmgb, string name, string lastname, List<Allergy> allergies)
        {
            Jmgb = jmgb;
            Name = name;
            Lastname = lastname;
            Allergies = allergies;
        }
        
    }
}
