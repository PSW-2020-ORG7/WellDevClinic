using System;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model
{
    public class Sale
    {
        [Key]
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string SaleMessage { get; set; }
        public virtual Period ValPeriod { get; set; }
        public SaleStatus Status { get; set; }


        public Sale(long id, string pharmacyName, string messageAbouAction, DateTime startDate, DateTime endDate, SaleStatus status) {
            Validate();
            Id = id;
            PharmacyName = pharmacyName;
            SaleMessage = messageAbouAction;
            ValPeriod = new Period(startDate, endDate);
            Status = status;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(PharmacyName) || string.IsNullOrWhiteSpace(SaleMessage))
                throw new ArgumentNullException("Arguments: PharmacyName and MessageAboutAction can't be empty");
        }

        public Sale() { }
    }
}
