using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PSW_Pharmacy_Adapter.Dto;
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

        public ActionAndBenefit(ActionAndBenefitDtoConverted actionDto, ActionStatus status)
        {
            Id = actionDto.Id;
            PharmacyName = actionDto.PharmacyName;
            MessageAboutAction = actionDto.MessageAboutAction;
            StartDate = actionDto.StartDate;
            EndDate = actionDto.EndDate;
            Status = status;
        }
    }
}
