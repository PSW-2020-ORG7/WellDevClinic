using bolnica.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using WellDevCore.Model.dtos;
using System.Security.Claims;
using System.Collections.Generic;

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
        private IConfiguration _config;

        public UserController(IUserController userController, IConfiguration config)
        {
            _userController = userController;
            _config = config;
        }

        [HttpPost]
        //[Route("loginuser")]
        public User Login(LoginModel loginModel)
        {
            User user = _userController.Login(loginModel.username, loginModel.password);

            return user;
        }
        [HttpPost]
        [Route("login")]
        public String Login(UserDTO user)
        {
            User retVal = _userController.Login(user.Username, user.Password);
            String tokenString = "";
            if (retVal != null)
                tokenString = GenerateJWT(retVal);

            return tokenString;
        }

        private String GenerateJWT(User user)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimUserType = new Claim("type", user.Type.ToString());
            var claimId = new Claim("Id", user.Id.ToString());
            var claims = new List<Claim>();
            claims.Add(claimUserType);
            claims.Add(claimId);

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
