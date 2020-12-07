using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using PSW_Web_app.dtos;
using bolnica.Model.dtos;
using System.Runtime.CompilerServices;
using Model.Dto;
/// <summary>
/// Mapps Examination to ExaminationDto
/// </summary>
namespace bolnica.Model.Adapters
{
    public class ExaminationAdapter
    {
        public static ExaminationDto ExaminationToExaminationDto(Examination examination)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.drug = new List<String>();
            dto.doctor = examination.Doctor.FullName;
            dto.date = examination.Period.StartDate.Date.ToShortDateString();

            foreach (Drug d in examination.Prescription.Drug) {
                dto.drug.Add(d.Name);
            }
            dto.specialist = examination.Refferal.Doctor.FullName;
            dto.textReferral = examination.Refferal.Text;
            return dto;
        }

       
    }
}
