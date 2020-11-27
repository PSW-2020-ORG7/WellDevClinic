using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.PatientSecretary;

namespace bolnica.Model.dtos
{
    public class ReferralDto
    {
        public String specialist;
        public DateTime date;
        public String text;

        public ReferralDto() { }
    }
}
