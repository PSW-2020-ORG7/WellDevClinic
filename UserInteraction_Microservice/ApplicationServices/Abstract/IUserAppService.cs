using System;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices.Abstract
{
    public interface IUserAppService
    {
        public User LogIn(string Username, string Password);

        public User Registration(User user);

        public String GenerateJWT(User user);


    }
}
