using Model.PatientSecretary;
using System.Collections.Generic;

namespace WellDevCore.Model.dtos
{
    public class PatientPrescriptionDTO
    {
        public long Id { get; set; }
        public virtual Period TimePeriod { get; set; }
        public virtual List<Drug> Drugs { get; set; }
        public string PatJmbg { get; set; }
        public string PatFirstName { get; set; }
        public string PatLastName { get; set; }

        public PatientPrescriptionDTO() { }

        public PatientPrescriptionDTO(long id, Period period, List<Drug> drugs, string jmbg, string firstName, string lastName)
        {
            Id = id;
            TimePeriod = period;
            Drugs = drugs;
            PatJmbg = jmbg;
            PatFirstName = firstName;
            PatLastName = lastName;
        }
    }
}
