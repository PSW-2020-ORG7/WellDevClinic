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
        public virtual Prescription prescription { get; set; }
        public virtual Anemnesis Anemnesis { get; set; }
        public virtual Patient Patient { get; set; }
        public long Id { get; set; }


    }
}