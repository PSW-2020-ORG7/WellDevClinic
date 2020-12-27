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
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public Boolean Registration()
        {
            User director = new Director(0, "2229999123", "Pera", "Peric", new DateTime(), "021321231", "Paja", "", "Musko", "blabla@gmail.com", "", null, "pera", "pera", UserType.Director);
            if (_userAppService.Save(director) != null)
                return true;
            return false;
        }
    }
}