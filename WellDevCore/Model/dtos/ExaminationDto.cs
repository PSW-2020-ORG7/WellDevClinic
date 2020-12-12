using bolnica.Controller.decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using Model.PatientSecretary;
/// <summary>
/// Models Examination for showing on frontend
/// </summary>
namespace bolnica.Model.dtos
{
    public class ExaminationDto
    {
        public String specialist { get; set; }
        public String textReferral { get; set; }
        public String doctor { get; set; }
        public List<String> drug { get; set; }
        public String date { get; set; }

        public String startTime { get; set; }
        public String endTime { get; set; }
        public String diagnosis { get; set; }
        public String therapy { get; set; }

        public Boolean filledSurvey { get; set; }
        public long id { get; set; }
        public Boolean canBeCanceled { get; set; }
        public Boolean canceled { get; set; }
        public ExaminationDto() { }
       
    }
}
