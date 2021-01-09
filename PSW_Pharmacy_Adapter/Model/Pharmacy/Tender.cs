using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Model.Pharmacy
{
    public class Tender
    {
        [Key]
        public long? Id { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Tender() { }

        public Tender(long? id, List<Medication> medications, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Medications = medications;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Tender(long? id)
        {
            Id = id;
        }
    }
}
