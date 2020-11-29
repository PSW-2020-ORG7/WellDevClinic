using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.PatientSecretary;

namespace bolnica.Model.dtos
{
    public class PrescriptionDto
    {
        public List<String> drug;
        public Period period;

        public PrescriptionDto() { }
    }
}
