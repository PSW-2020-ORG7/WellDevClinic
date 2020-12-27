using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.DomainServices;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;

        public UserAppService(IUserDomainService userDomainService) 
        {
            _userDomainService = userDomainService;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User entity)
        {
            return _userDomainService.Save(entity);
        }
    }
}
