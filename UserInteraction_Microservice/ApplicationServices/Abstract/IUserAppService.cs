using System;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IUserAppService
    {
        public User LogIn(String username, String password);
    }
}
