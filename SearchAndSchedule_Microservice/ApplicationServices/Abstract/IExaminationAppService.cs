using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface IExaminationAppService : ICRUD<Examination,long>
    {
    }
}
