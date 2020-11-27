using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class ActionAndBenefit
    {
        public long Id { get; set; }
        public long IdPublisher { get; set; }
        public string MessageFromPublisher { get; set; }

        public ActionAndBenefit() { }

        public ActionAndBenefit(long id, long idPublisher, string messageFromPublisher) {
            Id = id;
            IdPublisher = idPublisher;
            MessageFromPublisher = messageFromPublisher;
        }

    }
}
