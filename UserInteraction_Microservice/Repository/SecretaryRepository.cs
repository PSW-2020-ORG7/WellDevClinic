﻿using System.Collections.Generic;
using System.Linq;
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
                    Person = s.Person,
                    UserType = s.UserType

                }
            ).Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Secretary> GetAll()
        {
            return _myDbContext.Secretary.Select(s =>
                new Secretary()
                {
                    Id = s.Id,
                    Person = s.Person,
                    UserType = s.UserType

                }
            ).DefaultIfEmpty().ToList();
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            return _myDbContext.Secretary.DefaultIfEmpty().ToList();
        }

        public Secretary GetEager(long id)
        {
            return _myDbContext.Secretary.FirstOrDefault(s => s.Id == id);
        }

        public Secretary GetUserByCredentials(string username, string password)
        {
            var logIn = _myDbContext.UserLogIn.Where(p => p.Username.Equals(username) && p.Password.Equals(password)).FirstOrDefault();
            if (logIn != null)
                return _myDbContext.Secretary.Select(d =>
                    new Secretary()
                    {
                        Id = d.Id,
                        Person = d.Person,
                        UserType = d.UserType
                    }
                ).Where(d => d.Id == logIn.Id).FirstOrDefault();
            return null;
        }

        public Secretary Save(Secretary entity)
        {
            var Secretary = _myDbContext.Secretary.Add(entity);
            _myDbContext.SaveChanges();
            return Secretary.Entity;
        }
    }
}
