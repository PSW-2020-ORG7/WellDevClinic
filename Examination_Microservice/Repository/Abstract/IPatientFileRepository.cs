using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Repository.Abstract
{
    public interface IPatientFileRepository : ICRUD<PatientFile,long>
    {
    }
}
