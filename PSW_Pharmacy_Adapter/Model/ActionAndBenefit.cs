using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class ActionAndBenefit
    {
        [Key]
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string MessageAboutAction { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public ActionAndBenefit() { }


        public ActionAndBenefit(long id, string pharmacyName, string messageAbouAction, string startDate, string endDate) {
            Id = id;
            PharmacyName = pharmacyName;
            MessageAboutAction = messageAbouAction;
            StartDate = startDate;
            EndDate = endDate;
        }



    }
}
