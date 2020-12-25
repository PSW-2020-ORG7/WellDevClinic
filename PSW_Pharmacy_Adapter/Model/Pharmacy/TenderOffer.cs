using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Model.Pharmacy
{
    public class TenderOffer
    {
        [Key]
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public virtual List<Medication> Medications { get; set; }
        public double Price { get; set; }
        public string Message { get; set; }

        public TenderOffer() { }

        public TenderOffer(long id, string pharmacyName, List<Medication> medications, double price, string message)
        {
            Id = id;
            PharmacyName = pharmacyName;
            Medications = medications;
            Price = price;
            Message = message;
        }


    }
}
