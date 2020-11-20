﻿using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Web_app.dtos;


namespace PSW_Web_app.Adapters
{
    public class PrescriptionAdapter
    {
        public static PrescriptionDto PrescriptionToPrescriptionDto(Prescription prescription)
        {
            PrescriptionDto dto = new PrescriptionDto();
            dto.period = prescription.Period;
            foreach (Drug drug in prescription.Drug) {
                dto.drug.Add(drug.Name);
            }
            return dto;
        }
    }
}
