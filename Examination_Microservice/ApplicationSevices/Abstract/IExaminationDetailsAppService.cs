using Examination_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices.Abstract
{
    public interface IExaminationDetailsAppService : ICRUD<ExaminationDetails, long>
    {
        public IEnumerable<ExaminationDetails> GetExaminationDetailsByDoctor(Doctor doctor);
        public IEnumerable<ExaminationDetails> GetExaminationDetailsByPatient(Patient patient);

    }
}
