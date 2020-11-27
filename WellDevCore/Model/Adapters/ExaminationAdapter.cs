using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using PSW_Web_app.dtos;
using bolnica.Model.dtos;
using System.Runtime.CompilerServices;
using Model.Dto;

namespace bolnica.Model.Adapters
{
    public class ExaminationAdapter
    {
        public static ExaminationDto ExaminationToExaminationDto(Examination examination)//, ReferralDto referral, PrescriptionDto prescription)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.ReferralDtoId = examination.Refferal.Id;
            dto.PrescriptionDtoId = examination.Prescription.Id;
            //dto.prescription = prescription;
            //dto.referral = referral;
            dto.doctor = examination.Doctor.FullName;
            dto.date = examination.Period.StartDate;
            
            return dto;
        }

        /*public static ExaminationDbDto ExaminationToExaminationDbDto(Examination examination)
        {
            ExaminationDbDto dto = new ExaminationDbDto();
            dto.AnemnesisId = examination.Id;
        }*/
    }
}
