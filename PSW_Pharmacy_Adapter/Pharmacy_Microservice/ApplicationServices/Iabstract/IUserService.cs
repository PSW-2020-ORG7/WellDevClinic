using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Users_Microservice.ApplicationServices.Iabstract
{
    public interface IUserService
    {
        public Task<User> GetUser(User user);
    }
}
