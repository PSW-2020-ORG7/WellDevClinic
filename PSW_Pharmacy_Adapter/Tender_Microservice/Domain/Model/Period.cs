using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class Period
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        ///public Period() { }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Validate();
        }

        private void Validate()
        {
            if (StartDate >= EndDate)
                throw new ArgumentException("Invalid argument", nameof(StartDate));
        }

        public Boolean ComparePeriod(Period period)
        {
            if (DateTime.Compare(period.StartDate.Date, this.StartDate.Date) >= 0 && DateTime.Compare(period.EndDate.Date, this.EndDate.Date) <= 0)
                return true;
            return false;
        }
    }
}
