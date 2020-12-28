using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDirectorAppService _directorAppService;

        public UserController(IDirectorAppService directorAppService)
        {
            _directorAppService = directorAppService;
               
        }

        [HttpGet]
        public Boolean Registration()
        {
            Person person = new Person(0, "Pera", "Peric", "213123123123");
            UserDetails userDetails = new UserDetails(0, new DateTime(), "2131233", "Paja", "", "Musko", "sadas@gmail.com", "", null);
            UserLogIn userLogIn = new UserLogIn(0, "pera", "pera", UserType.Director);
            User user = new User(person, userDetails, userLogIn);
            Director director = new Director(0, user);
            _directorAppService.Save(director);
            return false;
        }
    }
}