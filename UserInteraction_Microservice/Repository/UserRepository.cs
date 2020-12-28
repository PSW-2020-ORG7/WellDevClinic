using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Save(User entity)
        {
            dbContext.Person.Add(entity.Person);
            dbContext.UserDetails.Add(entity.UserDetails);
            dbContext.UserLogIn.Add(entity.UserLogIn);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
