﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class TenderOffer
    {
        [Key]
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public double Price { get; set; }
        public string Message { get; set; }
        public long TenderId { get; set; }
        public virtual Email Mail { get; set; }

        public TenderOffer() { }

        public TenderOffer(long? id, string pharmacyName, List<Medication> medications, double price, string message, long tender, string email)
        {
            Id = id;
            PharmacyName = pharmacyName;
            Medications = medications;
            Price = price;
            Message = message;
            TenderId = tender;
            Mail = new Email(email);
        }
    }
}
