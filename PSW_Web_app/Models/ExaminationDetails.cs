﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PSW_Web_app.Models.Examination;

namespace PSW_Web_app.Models
{
    public class ExaminationDetails: IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }
        public virtual Therapy Therapy { get; set; }
        public virtual Sympthom Sympthom { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public Boolean FilledSurvey { get; set; }
        public virtual Period Period { get; set; }
        public virtual Referral Referral { get; set; }

        public ExaminationDetails() { }

        public ExaminationDetails(long id, Diagnosis diagnosis, Prescription prescription, Anamnesis anamnesis, Therapy therapy, Sympthom sympthom, Doctor doctor, Patient patient, bool filledSurvey) : this(id, diagnosis, prescription, anamnesis, therapy, sympthom)
        {
            Doctor = doctor;
            Patient = patient;
            FilledSurvey = filledSurvey;
        }

        public ExaminationDetails(long id, Diagnosis diagnosis, Prescription prescription, Anamnesis anamnesis, Therapy therapy, Sympthom sympthom)
        {
            Id = id;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Anamnesis = anamnesis;
            Therapy = therapy;
            Sympthom = sympthom;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
