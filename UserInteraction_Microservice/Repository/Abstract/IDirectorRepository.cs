using System;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IDirectorRepository : ICRUD<Director, long>, IGetEager<Director,long>
    {
        public Director GetUserByCredentials(String username, String password);
    }
}
