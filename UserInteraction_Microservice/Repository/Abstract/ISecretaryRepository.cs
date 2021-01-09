using System;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface ISecretaryRepository : ICRUD<Secretary, long>, IGetEager<Secretary, long>
    {
        public Secretary GetUserByCredentials(String username, String password);
    }
}
