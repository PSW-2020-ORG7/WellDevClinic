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
        public long Id { get; set; }
        public string NamePublisher { get; set; }
        public string MessageFromPublisher { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public ActionAndBenefit() { }

        public ActionAndBenefit(long id, string namePublisher, string messageFromPublisher, string startDate, string endDate) {
            Id = id;
            NamePublisher = namePublisher;
            MessageFromPublisher = messageFromPublisher;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
