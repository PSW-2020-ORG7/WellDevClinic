using System;

namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model
{
    public class Period
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

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

        public bool ComparePeriod(Period period)
        {
            if (DateTime.Compare(period.StartDate.Date, StartDate.Date) >= 0 && DateTime.Compare(period.EndDate.Date, EndDate.Date) <= 0)
                return true;
            return false;
        }
    }
}
