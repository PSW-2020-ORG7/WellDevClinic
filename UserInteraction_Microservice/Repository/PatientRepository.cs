using System.Collections.Generic;
using System.Linq;
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
                    Person = p.Person,
                    Blocked = p.Blocked,
                    Guest = p.Guest,
                    UserType = p.UserType

                }
            ).Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _myDbContext.Patient.Select(p =>
               new Patient()
               {
                   Id = p.Id,
                   Person = p.Person,
                   Blocked = p.Blocked,
                   Guest = p.Guest,
                   UserType = p.UserType

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

        public Patient GetUserByCredentials(string username, string password)
        {
            var logIn = _myDbContext.UserLogIn.Where(p => p.Username.Equals(username) && p.Password.Equals(password)).FirstOrDefault();
            if(logIn != null)
                return _myDbContext.Patient.Select(d =>
                    new Patient()
                    {
                        Id = d.Id,
                        Person = d.Person,
                        Blocked = d.Blocked,
                        Guest = d.Guest
                    }
                ).Where(d => d.Id == logIn.Id).FirstOrDefault();
            return null;
        }

        public Patient Save(Patient entity)
        {
            _myDbContext.Patient.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
