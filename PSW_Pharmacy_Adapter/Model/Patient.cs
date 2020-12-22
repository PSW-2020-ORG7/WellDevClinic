using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Patient
    {

        public long Jmbg { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public List<Allergy> Allergies { get; set; }


        public Patient() { }
        public Patient(long jmbg, string name, string lastname, List<Allergy> allergies)
        {
            Jmbg = jmbg;
            Name = name;
            Lastname = lastname;
            Allergies = allergies;
        }
        public Patient(long jmbg, string name, string lastname)
        {
            Jmbg = jmbg;
            Name = name;
            Lastname = lastname;
        }

    }
}
