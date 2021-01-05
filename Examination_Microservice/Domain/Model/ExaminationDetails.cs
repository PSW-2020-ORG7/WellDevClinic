using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class ExaminationDetails: IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Anamnesis Anamnesis { get; set; }
        public virtual Therapy Therapy { get; set; }
        public virtual Sympthom Sympthom { get; set; }

        public ExaminationDetails() { }

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
