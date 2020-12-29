using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MyDbContext _myDbContext;

        public PatientRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Patient entity)
        {
            _myDbContext.Patient.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Patient entity)
        {
            _myDbContext.Patient.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Patient Get(long id)
        {
            return _myDbContext.Patient.Select(p =>
                new Patient()
                {
                    Id = p.Id,
                    User = new User(p.Id, p.User.Person, null,null),
                    Blocked = p.Blocked,
                    Guest = p.Guest
                }
            ).Where(p => p.Id == id).First();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _myDbContext.Patient.Select(p =>
               new Patient()
               {
                   Id = p.Id,
                   User = new User(p.Id, p.User.Person, null, null),
                   Blocked = p.Blocked,
                   Guest = p.Guest
               }
           ).ToList();
        }

        public IEnumerable<Patient> GetAllEager()
        {
            return _myDbContext.Patient.ToList();
        }

        public Patient GetEager(long id)
        {
            return _myDbContext.Patient.FirstOrDefault(p => p.Id == id);
        }

        public Patient Save(Patient entity)
        {
            _myDbContext.Patient.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
