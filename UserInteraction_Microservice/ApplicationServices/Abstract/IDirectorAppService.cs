using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IDirectorAppService : ICRUD<Director, long>, IGetEager<Director, long>
    {
        public Director LogIn(String username, String password);
    }
}
