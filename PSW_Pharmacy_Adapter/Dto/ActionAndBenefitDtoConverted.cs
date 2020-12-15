using System;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class ActionAndBenefitDtoConverted
    {
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string MessageAboutAction { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ActionAndBenefitDtoConverted() { }


        public ActionAndBenefitDtoConverted(long? id, string pharmacyName, string messageAboutAction, DateTime startDate, DateTime endDate)
        {
            Id = id;
            PharmacyName = pharmacyName;
            MessageAboutAction = messageAboutAction;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
