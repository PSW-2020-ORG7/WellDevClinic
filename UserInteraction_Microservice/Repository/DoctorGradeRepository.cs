using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class DoctorGradeRepository : IDoctorGradeRepository
    {
        private readonly MyDbContext _myDbContext;
        public DoctorGradeRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(DoctorGrade entity)
        {
            _myDbContext.DoctorGrade.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(DoctorGrade entity)
        {
            _myDbContext.DoctorGrade.Update(entity);
            _myDbContext.SaveChanges();
        }

        public DoctorGrade Get(long id)
        {
            return _myDbContext.DoctorGrade.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _myDbContext.DoctorGrade.DefaultIfEmpty().ToList();
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            Doctor doctor = _myDbContext.Doctor.Where(a => a.Person.FirstName == entity.Doctor.Person.FirstName && a.Person.LastName == entity.Doctor.Person.LastName).FirstOrDefault();
            entity.Doctor = doctor;
            var DoctorGrade = _myDbContext.DoctorGrade.Add(entity);
            _myDbContext.SaveChanges();
            return DoctorGrade.Entity;
        }

        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            string[] names = doctor.Split(" ");
            return _myDbContext.DoctorGrade.Where(a => a.Doctor.Person.FirstName == names[0] && a.Doctor.Person.LastName == names[1]).ToList();
        }
    }
}
