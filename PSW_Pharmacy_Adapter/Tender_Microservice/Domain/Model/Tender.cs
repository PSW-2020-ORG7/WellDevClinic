using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class Tender
    {
        [Key]
        public long? Id { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long OfferWinner { get; set; }
        public bool IsDeleted { get; set; }

        public Tender() { }

        public Tender(long? id, List<Medication> medications, DateTime startDate, DateTime endDate, long offerWinner, bool isDeleted)
        {
            Id = id;
            Medications = medications;
            StartDate = startDate;
            EndDate = endDate;
            OfferWinner = offerWinner;
            IsDeleted = isDeleted;
        }

        public Tender(long? id)
        {
            Id = id;
        }
    }
}
