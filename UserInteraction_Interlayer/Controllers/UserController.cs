using Microsoft.AspNetCore.Mvc;
using System;
using UserInteraction_Interlayer.Models;
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

        [HttpGet]
        public User LogIn(string username, string password)
        {
            return _userAppService.LogIn(username, password);
        }

        [HttpPost]
        [Route("patient")]
        public String LogInPatient(UserLoginDTO user)
        {
            User retVal = _userAppService.LogIn(user.Username,user.Password);
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