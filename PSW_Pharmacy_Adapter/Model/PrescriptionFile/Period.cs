using System;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long Id { get; set; }


        public Period() { }

        public Period(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate.Value;
            EndDate = endDate.Value;
        }
    }
}
