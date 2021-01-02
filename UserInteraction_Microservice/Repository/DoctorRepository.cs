using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MyDbContext _myDbContext;

        public DoctorRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Doctor entity)
        {
            _myDbContext.Doctor.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Doctor entity)
        {
            _myDbContext.Doctor.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Doctor Get(long id)
        {
            return _myDbContext.Doctor.Select(d =>
                new Doctor()
                {
                    Id = d.Id,
                    Person = d.Person,
                    Speciality = d.Speciality,
                    DoctorGrade = d.DoctorGrade,
                    UserType = d.UserType
                }

            ).Where(d => d.Id == id).FirstOrDefault();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _myDbContext.Doctor.Select(d =>
                new Doctor()
                {
                    Id = d.Id,
                    Person = d.Person,
                    Speciality = d.Speciality,
                    DoctorGrade = d.DoctorGrade,
                    UserType = d.UserType

                }

            ).ToList();
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            return _myDbContext.Doctor.ToList();
        }

        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality speciality)
        {
            return _myDbContext.Doctor.Select(d =>
              new Doctor()
              {
                  Id = d.Id,
                  Person = d.Person,
                  Speciality = d.Speciality,
                  DoctorGrade = d.DoctorGrade,
                  UserType = d.UserType

              }

          ).Where(d => d.Speciality.Name.Equals(speciality.Name)).ToList();
        }

        public Doctor GetEager(long id)
        {
            return _myDbContext.Doctor.FirstOrDefault(d => d.Id == id);
        }

        public Doctor GetUserByCredentials(string username, string password)
        {
            var logIn = _myDbContext.UserLogIn.Where(p => p.Username.Equals(username) && p.Password.Equals(password)).FirstOrDefault();
            if (logIn != null)
                return _myDbContext.Doctor.Select(d =>
                    new Doctor()
                    {
                        Id = d.Id,
                        Person = d.Person,
                        Speciality = d.Speciality,
                        DoctorGrade = d.DoctorGrade,
                        UserType = d.UserType
                        
                    }
                ).Where(d => d.Id == logIn.Id).FirstOrDefault();
            return null;
        }

        public Doctor Save(Doctor entity)
        {
            var Doctor = _myDbContext.Doctor.Add(entity);
            _myDbContext.SaveChanges();
            return Doctor.Entity;
        }
    }
}
