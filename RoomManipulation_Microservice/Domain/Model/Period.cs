using System;
using System.Reflection;

namespace RoomManipulation_Microservice.Domain.Model
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period(DateTime startDate, DateTime endDate)
        {
            Validate(startDate, EndDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        public Period() { }

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