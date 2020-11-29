using bolnica.Controller.decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using Model.PatientSecretary;

namespace bolnica.Model.dtos
{
    public class ExaminationDto
    {
        //public ReferralDto referral;
        public long ReferralDtoId;
        public String doctor;
        //public PrescriptionDto prescription;
        public long PrescriptionDtoId;
        public DateTime date;

        public ExaminationDto() {}
    }
}
