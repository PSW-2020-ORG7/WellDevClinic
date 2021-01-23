using System;
using System.Collections.Generic;
using System.Text;
using PSW_Web_app.Models.Examination;

namespace PSW_Web_app.Models
{
    public class Referral : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Text { get; set; }
        public virtual Period Period { get; set; }
        public virtual Doctor Doctor { get; set; }

        public Referral() { }

        public Referral(long id, string text, Period period, Doctor doctor)
        {
            Id = id;
            Text = text;
            Period = period;
            Doctor = doctor;
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
