using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Users_Microservice.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Users_Microservice.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        public User Get(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User entity)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
