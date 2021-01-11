using System;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model
{
    public class ActionAndBenefit
    {
        [Key]
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string MessageAboutAction { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActionStatus Status { get; set; }

        public ActionAndBenefit() { }


        public ActionAndBenefit(long id, string pharmacyName, string messageAbouAction, DateTime startDate, DateTime endDate, ActionStatus status) {
            Id = id;
            PharmacyName = pharmacyName;
            MessageAboutAction = messageAbouAction;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
