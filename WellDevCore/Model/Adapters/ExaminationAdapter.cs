﻿using Model.PatientSecretary;
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
            dto.date = examination.Period.StartDate.Date.ToString("yyyy-MM-dd");
            foreach (Drug d in examination.Prescription.Drug) {
                dto.drug.Add(d.Name);
            }
            dto.specialist = examination.Refferal.Doctor.FullName;
            dto.textReferral = examination.Refferal.Text;
            return dto;
        }

        public static ExaminationDto ExaminationPreviousToExaminationDto(Examination examination)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.doctor = examination.Doctor.FullName;
            dto.date = examination.Period.StartDate.Date.ToShortDateString();
            dto.startTime = examination.Period.StartDate.ToShortTimeString();
            dto.endTime = examination.Period.EndDate.ToShortTimeString();
            dto.diagnosis = examination.Diagnosis.Name;
            dto.therapy = examination.Therapy.Note;
            dto.filledSurvey = examination.FilledSurvey;
            dto.id = examination.Id;
            dto.canceled = examination.Canceled;
            return dto;
        }

        public static ExaminationDto ExaminationUpcomingToExaminationDto(Examination examination)
        {
            ExaminationDto dto = new ExaminationDto();
            dto.doctor = examination.Doctor.FullName;
            dto.date = examination.Period.StartDate.Date.ToShortDateString();
            dto.startTime = examination.Period.StartDate.ToShortTimeString();
            dto.endTime = examination.Period.EndDate.ToShortTimeString();
            dto.id = examination.Id;
            dto.canceled = examination.Canceled;

            if (DateTime.Compare(DateTime.Now.AddDays(2), examination.Period.StartDate) < 0)
            {
                dto.canBeCanceled = true;
            }
            else
            {
                dto.canBeCanceled = false;
            }

            return dto;
        }


    }
}
