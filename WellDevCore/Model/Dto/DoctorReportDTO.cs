using Model.PatientSecretary;
using Model.Users;
using System;

namespace Model.Dto
{
   public class DoctorReportDTO
   {
        public DoctorReportDTO(Prescription prescription, Anemnesis anemnesis, Patient patient)
        {
            this.prescription = prescription;
            Anemnesis = anemnesis;
            Patient = patient;
        }
        public DoctorReportDTO() { }
        public Prescription prescription { get; set; }
        public Anemnesis Anemnesis { get; set; }
        public Patient Patient { get; set; }
        public long Id { get; set; }


    }
}