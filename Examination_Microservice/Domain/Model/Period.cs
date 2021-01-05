using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period() { }
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public Period(DateTime startDate)
        {
            StartDate = startDate;
        }

    }
}
