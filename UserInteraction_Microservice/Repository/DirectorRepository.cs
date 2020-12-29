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
            _myDbContext.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Director entity)
        {
            _myDbContext.Director.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Director Get(long id)
        {
            var director = _myDbContext.Director.Select(d =>
                new Director()
                {
                    Id = d.Id,
                    User = new User(d.Id, d.User.Person, null, null)
                }

            ).Where(d => d.Id == id); 
            return director.First();
        }

        public IEnumerable<Director> GetAll()
        {
            return _myDbContext.Director.Select(d =>
                new Director()
                {
                    Id = d.Id,
                    User = new User(d.Id,d.User.Person, null, null)
                }
            ).ToList();
        }

        public IEnumerable<Director> GetAllEager()
        {
            return _myDbContext.Director.ToList();
        }

        public Director GetEager(long id)
        {
            return  _myDbContext.Director.FirstOrDefault(director => director.Id == id);
             
        }

        public Director Save(Director entity)
        {
            _myDbContext.Director.Add(entity);
            _myDbContext.SaveChanges();
            return entity;

        }
    }
}
