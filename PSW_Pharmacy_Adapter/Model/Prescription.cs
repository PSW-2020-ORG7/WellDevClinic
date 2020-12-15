using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Prescription
    {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual List<Medication> Medication { get; set; }
        public Patient CurrentPatient { get; set; }
        public string QrPath { get; set; }

        public Prescription() { }
        public Prescription(long id, Period period, List<Medication> medication, Patient currentPatient, string qrPath)
        {
            Id = id;
            Period = period;
            Medication = medication;
            CurrentPatient = currentPatient;
            QrPath = qrPath;
        }

    
    }
}
