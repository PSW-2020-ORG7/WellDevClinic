using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class ActionAndBenefitDto
    {
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string MessageAboutAction { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ActionAndBenefitDto() { }


        public ActionAndBenefitDto(long id, string pharmacyName, string messageAbouAction, DateTime startDate, DateTime endDate)
        {
            Id = id;
            PharmacyName = pharmacyName;
            MessageAboutAction = messageAbouAction;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
