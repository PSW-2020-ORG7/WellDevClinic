using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Web_app.dtos;
using System.Runtime.CompilerServices;

namespace PSW_Web_app.Adapters
{
    public class ExaminationAdapter
    {
        public static ExaminationDto ExaminationToExaminationDto(Examination examination, ReferralDto referral, PrescriptionDto prescription)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.prescription = prescription;
            dto.referral = referral;
            dto.doctor = examination.Doctor.FullName;
            dto.date = examination.Period.StartDate;
            
            return dto;
        }
    }
}
