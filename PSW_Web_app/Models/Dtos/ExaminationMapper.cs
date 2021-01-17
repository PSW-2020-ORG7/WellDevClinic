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
            dto.Drug = new List<String>();
            dto.Doctor = examination.Doctor.Person.FullName;
            dto.Date = examination.Period.StartDate.Date.ToString("yyyy-MM-dd");
            if (examination.Prescription != null)
            {
                foreach (Drug d in examination.Prescription.Drug)
                {
                    dto.Drug.Add(d.Name);
                }
            }
            if (examination.Referral != null)
            {
                dto.Specialist = examination.Referral.Doctor.Person.FullName;
                dto.TextReferral = examination.Referral.Text;
            }
            else {
                dto.Specialist = "";
                dto.TextReferral = "";
            }
            return dto;
        }
    }
}
