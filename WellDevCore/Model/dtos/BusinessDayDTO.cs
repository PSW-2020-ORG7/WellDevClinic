using Model.Director;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.dtos
{
    public class BusinessDayDTO
    {
        public BusinessDayDTO() { }

        public Period Shift { get; set; }
        public List<Period> ScheduledPeriods { get; set; } = new List<Period>();
        public Room Room { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long ShiftId { get; set; }
        public long BusinessDayId { get; set; }

         
    }
}
