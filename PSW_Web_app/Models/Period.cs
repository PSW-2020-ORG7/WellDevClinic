using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace PSW_Web_app.Models
{
    [NotMapped]
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period() {}

        public Period(DateTime startDate, DateTime endDate)
        {
            Validate(startDate, EndDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        private void Validate(DateTime startDate, DateTime endDate)
        {
            if (startDate <= endDate)
                throw new CustomAttributeFormatException();
        }

        public Period(DateTime startDate)
        {
            StartDate = startDate;
        }

        public Boolean ComparePeriod(Period period)
        {
            if (DateTime.Compare(period.StartDate.Date, this.StartDate.Date) >= 0 && DateTime.Compare(period.EndDate.Date, this.EndDate.Date) <= 0)
                return true;
            return false;
        }
    }
   
}
