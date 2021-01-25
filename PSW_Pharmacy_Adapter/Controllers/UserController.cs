

using Microsoft.AspNetCore.Mvc;
using PSW_Pharmacy_Adapter.Users_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GetPharmacyByMedicationsAsync([FromBody] User user)
            => Ok(await _userService.GetUser(user));
    }
}
