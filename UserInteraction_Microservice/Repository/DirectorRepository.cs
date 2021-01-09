using System.Collections.Generic;
using System.Linq;
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
            return _myDbContext.Director.Select(d =>
                new Director()
                {
                    Id = d.Id,
                    Person = d.Person,
                    UserType = d.UserType
                }

            ).Where(d => d.Id == id).FirstOrDefault();
            
        }

        public IEnumerable<Director> GetAll()
        {
            return _myDbContext.Director.Select(d =>
                new Director()
                {
                    Id = d.Id,
                    Person = d.Person,
                    UserType = d.UserType

                }
            ).DefaultIfEmpty().ToList();
        }

        public IEnumerable<Director> GetAllEager()
        {
            return _myDbContext.Director.DefaultIfEmpty().ToList();
        }

        public Director GetEager(long id)
        {
            return  _myDbContext.Director.FirstOrDefault(director => director.Id == id);
             
        }

        public Director GetUserByCredentials(string username, string password)
        {
            var logIn = _myDbContext.UserLogIn.Where(p => p.Username.Equals(username) && p.Password.Equals(password)).FirstOrDefault();
            if (logIn != null)
                return _myDbContext.Director.Select(d =>
                    new Director()
                    {
                        Id = d.Id,
                        Person = d.Person,
                        UserType = d.UserType
                    }
                ).Where(d => d.Id == logIn.Id).FirstOrDefault();
            return null;
        }

        public Director Save(Director entity)
        {
            var Director = _myDbContext.Director.Add(entity);
            _myDbContext.SaveChanges();
            return Director.Entity;

        }
    }
}
