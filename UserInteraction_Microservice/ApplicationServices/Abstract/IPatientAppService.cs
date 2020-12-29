using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IPatientAppService : ICRUD<Patient, long>, IGetEager<Patient, long>
    {
        public Patient LogIn(String username, String password);
    }
}
