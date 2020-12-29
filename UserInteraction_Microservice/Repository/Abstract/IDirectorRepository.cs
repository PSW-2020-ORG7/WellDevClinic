using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IDirectorRepository : ICRUD<Director, long>
    {
        public Director GetUserByCredentials(String username, String password);
    }
}
