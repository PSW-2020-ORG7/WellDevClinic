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
        public User LogIn(string username, string password)
        {
            return _userAppService.LogIn("pera", "pera");
        }

        [HttpPost]
        public User Registration(User user)
        {
            return _userAppService.Registration(user);
        }
    }
}