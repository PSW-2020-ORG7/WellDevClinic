using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Therapy : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Note { get; set; }
        public virtual Period Period { get; set; }
        public virtual List<Drug> Drug { get; set; }

        public Therapy() { }

        public Therapy(long id, string note, Period period, List<Drug> drug)
        {
            Id = id;
            Note = note;
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
