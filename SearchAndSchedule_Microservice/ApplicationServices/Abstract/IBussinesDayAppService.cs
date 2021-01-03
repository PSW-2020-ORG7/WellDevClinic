using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface  IBussinesDayAppService : ICRUD<BussinesDay, long>
    {
       
    }
}
