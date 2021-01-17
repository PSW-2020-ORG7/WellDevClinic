using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Models.Dtos
{
    public class ExaminationMapper
    {
        public static ExaminationDto ExaminationDetailsToExaminationDto(ExaminationDetails examination)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.drug = new List<String>();
            dto.doctor = examination.Doctor.Person.FullName;
            dto.date = examination.Period.StartDate.Date.ToString("yyyy-MM-dd");
            if (examination.Prescription != null)
            {
                foreach (Drug d in examination.Prescription.Drug)
                {
                    dto.drug.Add(d.Name);
                }
            }
            if (examination.Referral != null)
            {
                dto.specialist = examination.Referral.Doctor.Person.FullName;
                dto.textReferral = examination.Referral.Text;
            }
            else {
                dto.specialist = "";
                dto.textReferral = "";
            }
            return dto;
        }
    }
}
