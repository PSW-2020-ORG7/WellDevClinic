using bolnica.Controller.decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using Model.PatientSecretary;

namespace bolnica.Model.dtos
{
    public class ExaminationDto
    {
        public String specialist { get; set; }
        public String textReferral { get; set; }
        public String doctor { get; set; }
        public List<String> drug { get; set; }
        public String date { get; set; }

        public ExaminationDto() { }
        public ExaminationDto(string specialist, string textReferral, string doctor, List<string> drug, String date)
        {
            this.specialist = specialist;
            this.textReferral = textReferral;
            this.doctor = doctor;
            this.drug = drug;
            this.date = date;
        }
    }
}
