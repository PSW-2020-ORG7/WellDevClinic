using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.dtos
{
    public class ExaminationIdsDTO
    {
        public long DoctorId { get; set; }
        public String Period { get; set; }
        public long PatientId { get; set; }
        public ExaminationIdsDTO()
        {

        }
        public ExaminationIdsDTO(long doctorId, String period, long patientId)
        {
            DoctorId = doctorId;
            Period = period;
            PatientId = patientId;
        }
    }
}
