using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Period() { }

        public Period(DateTime start, DateTime end) 
        {
            this.StartDate = start;
            this.EndDate = end;
        }
    }
}
