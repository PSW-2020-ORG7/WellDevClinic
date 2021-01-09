using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class PatientFile : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual List<Hospitalization> Hospitalization { get; set; }
        public virtual List<Operation> Operation { get; set; }
        public virtual List<ExaminationDetails> Examination { get; set; }
        public virtual List<Allergy> Allergy { get; set; }

        public PatientFile() { }
        public PatientFile(long id, Patient patient, List<Hospitalization> hospitalization, List<Operation> operation, List<ExaminationDetails> examination, List<Allergy> allergy)
        {
            Id = id;
            Patient = patient;
            Hospitalization = hospitalization;
            Operation = operation;
            Examination = examination;
            Allergy = allergy;
        }

        public PatientFile(long id, List<Hospitalization> hospitalization, List<Operation> operation, List<ExaminationDetails> examination, List<Allergy> allergy)
        {
            Id = id;
            Hospitalization = hospitalization;
            Operation = operation;
            Examination = examination;
            Allergy = allergy;
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
