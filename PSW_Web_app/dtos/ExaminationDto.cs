using bolnica.Controller.decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using Model.PatientSecretary;

namespace PSW_Web_app.dtos
{
    public class ExaminationDto
    {
        public ReferralDto referral;
        public String doctor;
        public PrescriptionDto prescription;
        public DateTime date;

        public ExaminationDto() {}
    }
}
