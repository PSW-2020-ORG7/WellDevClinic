using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Prescription : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Period Period { get; set; }
        public virtual List<Drug> Drug { get; set; }

        public Prescription() { }

        public Prescription(long id, Period period, List<Drug> drug)
        {
            Id = id;
            Period = period;
            Drug = drug;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
