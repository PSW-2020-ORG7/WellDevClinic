using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Examination
    {
        public long Id { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
