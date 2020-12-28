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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Tender() { }

        public Tender(long? id, List<Medication> medications, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Medications = medications;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
}
