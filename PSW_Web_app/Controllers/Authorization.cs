using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Controllers
{
    public abstract class Authorization
    {
        public static Boolean Authorize(String role, String token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            String type = tokenS.Claims.First(claim => claim.Type == "type").Value;
            if (type.Equals(role))
                return true;
            else
                return false;
        }
    }
}
