using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MyDbContext _myDbContext;
        public DirectorRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public void Delete(Director entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Director entity)
        {
            throw new NotImplementedException();
        }

        public Director Get(long id)
        {
            // Director director = _myDbContext.Director.FirstOrDefault(director => director.Id == id);
            var director = _myDbContext.Director.Select(d =>
                new Director()
                {
                    Id = d.Id,
                    User = new User(d.User.Person, null, null)
                }

            ); ;
            return director.First();
        }

        public IEnumerable<Director> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Director GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public Director Save(Director entity)
        {
            _myDbContext.Director.Add(entity);
            _myDbContext.SaveChanges();
            return entity;

        }
    }
}
