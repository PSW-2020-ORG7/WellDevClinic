using Microsoft.AspNetCore.Mvc;
using System;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("login")]
        public User LogIn(UserLogIn user)
        {
            return _userAppService.LogIn(user);
        }

        [HttpPost]
        [Route("patient")]
        public String LogInPatient(UserLogIn user)
        {
            User retVal = _userAppService.LogIn(user);
            String tokenString = "";
            if (retVal != null)
                tokenString = _userAppService.GenerateJWT(retVal);

            return tokenString;
        }

        [HttpPost]
        public User Registration(User user)
        {
            return _userAppService.Registration(user);
        }

    }
}