using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    DoctorGrade = d.DoctorGrade
                }

            ).Where(d => d.Id == id).First();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _myDbContext.Doctor.Select(d =>
                new Doctor()
                {
                    Id = d.Id,
                    Person = d.Person,
                    Speciality = d.Speciality,
                    DoctorGrade = d.DoctorGrade
                }

            ).ToList();
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            return _myDbContext.Doctor.ToList();
        }

        public Doctor GetEager(long id)
        {
            return _myDbContext.Doctor.FirstOrDefault(d => d.Id == id);
        }

        public Doctor GetUserByCredentials(string username, string password)
        {
            return _myDbContext.Doctor.Select(d =>
                    new Doctor()
                    {
                        Id = d.Id,
                        Person = d.Person,
                        Speciality = d.Speciality,
                        DoctorGrade = d.DoctorGrade
                    }
            ).Where(d => d.UserLogIn.Username.Equals(username) && d.UserLogIn.Password.Equals(password)).First();
        }

        public Doctor Save(Doctor entity)
        {
            _myDbContext.Doctor.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }
    }
}
