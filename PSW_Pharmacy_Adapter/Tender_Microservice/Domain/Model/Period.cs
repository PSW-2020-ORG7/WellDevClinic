using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class Period
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        private Period() { }

        public Period(DateTime startDate, DateTime endDate)
        {
            Validate(startDate, endDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        private void Validate(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                throw new ArgumentNullException();
        }

        public Boolean ComparePeriod(Period period)
        {
            if (DateTime.Compare(period.StartDate.Date, this.StartDate.Date) >= 0 && DateTime.Compare(period.EndDate.Date, this.EndDate.Date) <= 0)
                return true;
            return false;
        }
    }
}
