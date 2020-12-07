using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class PatientFile : IIdentifiable<long>
    {
      public virtual List<Hospitalization> Hospitalization { get; set; }
      public virtual List<Operation> Operation { get; set; }
      public virtual List<Examination> Examination { get; set; }
      public virtual List<Allergy> Allergy { get; set; }

        public long Id { get; set; }

        public PatientFile(long id)
        {
            this.Id = id;
        }

        public PatientFile(long id, List<Allergy> allergy, List<Hospitalization> hospitalizations, List<Operation> operations, List<Examination> examinations)
        {
            Id = id;
            Hospitalization = hospitalizations;
            Operation = operations;
            Examination = examinations;
        }

        public PatientFile()
        {
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}