using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private readonly MyDbContext _myDbContext;

        public SecretaryRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Secretary entity)
        {
            _myDbContext.Secretary.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Secretary entity)
        {
            _myDbContext.Secretary.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Secretary Get(long id)
        {
            return _myDbContext.Secretary.Select(s =>
                new Secretary()
                {
                    Id = s.Id,
                    User = new User(s.Id, s.User.Person, null, null)
                }
            ).Where(s => s.Id == id).First();
        }

        public IEnumerable<Secretary> GetAll()
        {
            return _myDbContext.Secretary.Select(s =>
                new Secretary()
                {
                    Id = s.Id,
                    User = new User(s.Id, s.User.Person, null, null)
                }
            ).ToList();
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            return _myDbContext.Secretary.ToList();
        }

        public Secretary GetEager(long id)
        {
            return _myDbContext.Secretary.FirstOrDefault(s => s.Id == id);
        }

        public Secretary Save(Secretary entity)
        {
            _myDbContext.Secretary.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
