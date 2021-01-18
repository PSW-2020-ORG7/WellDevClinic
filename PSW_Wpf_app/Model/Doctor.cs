using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Doctor:User
    {
        public long Id { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual List<BusinessDay> BussinesDays { get; set; }

    }
}
