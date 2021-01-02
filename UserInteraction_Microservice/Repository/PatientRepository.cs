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
           ).DefaultIfEmpty().ToList();
        }

        public IEnumerable<Patient> GetAllEager()
        {
            return _myDbContext.Patient.DefaultIfEmpty().ToList();
        }


        public Patient Save(Patient entity)
        {
            var Patient = _myDbContext.Patient.Add(entity);
            _myDbContext.SaveChanges();
            return Patient.Entity;
        }


        public Patient GetEager(long id)
        {
            return _myDbContext.Patient.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetPatientByJMBG(string jmbg)
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
                ).Where(p => p.Person.Jmbg.Equals(jmbg)).FirstOrDefault();
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
                        Guest = d.Guest,
                        UserType = d.UserType
                         
                    }
                ).Where(d => d.Id == logIn.Id).FirstOrDefault();
            return null;
        }

        public List<Patient> GetBlockedPatients()
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
                ).Where(p => p.Blocked == true).DefaultIfEmpty().ToList();
        }

        public List<Patient> GetPatientsForBlocking()
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
              ).Where(p => p.Blocked == false).DefaultIfEmpty().ToList();
        }
    }
}
