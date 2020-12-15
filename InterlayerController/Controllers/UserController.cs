using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Model.Users;

namespace InterlayerController.Controllers
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserController _userController;

        public UserController(IUserController userController)
        {
            _userController = userController;
        }

        [HttpPost]
        //[Route("loginuser")]
        public User Login(LoginModel loginModel)
        {
            User user = _userController.Login(loginModel.username, loginModel.password);

            return user;
        }
    }
}
