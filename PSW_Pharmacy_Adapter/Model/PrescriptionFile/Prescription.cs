using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Prescription
    {
        public long Id { get; set; }
        public virtual Period TimePeriod { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public string PatJmbg { get; set; }
        public string PatFirstName { get; set; }
        public string PatLastName { get; set; }

        public Prescription() { }

        public Prescription(long id, Period period, List<Medication> medication, string jmbg, string firstName, string lastName)
        {
            Id = id;
            TimePeriod = period;
            Medications = medication;
            PatJmbg = jmbg;
            PatFirstName = firstName;
            PatLastName = lastName;
        }
    }
}
