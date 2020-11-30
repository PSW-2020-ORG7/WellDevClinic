using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.PatientSecretary;
using Repository;

namespace bolnica.Model.dtos
{
    public class PrescriptionDto:IIdentifiable<long>
    {
        public long Id { get; set; }
        private String period;
        private String drugs;

        public string Period { get => period; set => period = value; }
        public string Drugs { get => drugs; set => drugs = value; }

        public PrescriptionDto() { }

        public PrescriptionDto(long Id, String Period, String Drugs)
        {
            this.Id = Id;
            this.period = Period;
            this.drugs = Drugs;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}
