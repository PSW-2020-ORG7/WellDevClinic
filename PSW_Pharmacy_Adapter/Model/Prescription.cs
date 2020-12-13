using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Prescription
    {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual List<Medication> Medication { get; set; }

        public Prescription() { }
        public Prescription(long id, Period period)
        {
            Id = id;
            Period = period;
        }

        public Prescription(long id, Period period, List<Medication> alternative)
        {
            Period = period;
            Id = id;
            this.Medication = alternative;
        }

        public Prescription(Period period, List<Medication> drug)
        {
            Period = period;
            Medication = drug;
        }

        public Prescription(long id)
        {
            Id = id;
        }
    }
}
