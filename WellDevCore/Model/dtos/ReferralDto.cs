using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.PatientSecretary;

namespace bolnica.Model.dtos
{
    public class ReferralDto
    {
        public String Specialist;
        public String Period;
        public String Text;

        public ReferralDto() { }
    }
}
