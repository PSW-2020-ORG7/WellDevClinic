using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Repository.Abstract
{
    public interface IUserRepository
    {
        User Get(long id);
        IEnumerable<long> GetAll();
        User Save(User entity);
        void Delete(User entity);
        void Edit(User entity);
    }
}
