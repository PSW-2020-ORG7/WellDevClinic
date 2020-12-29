using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface ISecretaryAppService : ICRUD<Secretary, long>, IGetEager<Secretary, long>
    {
        public Secretary LogIn(String username, String password);
    }
}
