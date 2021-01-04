using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly MyDbContext _myDbContext;

        public SpecialityRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Speciality entity)
        {
            _myDbContext.Speciality.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Speciality entity)
        {
            _myDbContext.Speciality.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Speciality Get(long id)
        {
            return _myDbContext.Speciality.Select(s =>
                new Speciality()
                {
                    Id = s.Id,
                    Name=s.Name
                }
                ).Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _myDbContext.Speciality.Select(s =>
               new Speciality()
               {
                   Id = s.Id,
                   Name = s.Name
               }
               ).ToList();
        }

        public Speciality Save(Speciality entity)
        {
            var Speciality = _myDbContext.Speciality.Add(entity);
            _myDbContext.SaveChanges();
            return Speciality.Entity;
        }
    }
}
